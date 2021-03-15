using AnalisadorDeBytes.App.Dto;
using AnalisadorDeBytes.App.Extensao;
using AnalisadorDeBytes.Core.Componentes.GeradorDeLog;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.App
{
    public class AnalisadorApp : IAnalisadorApp
    {
        private readonly IAnalisador _analisador;
        private readonly IGeradorDeLog _geradorDeLog;
        private static readonly Regex _regex = new Regex(@"^(([a-zA-Z]:)|(\))(\{1}|((\{1})[^\]([^/:*?<>""|]*))+)$");

        public AnalisadorApp()
        {
            _analisador = new Analisador();
            _geradorDeLog = new GeradorDeLog();
        }

        public async Task<AnaliseDto> AnalisarAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            var retornoDaAnalise = await AnalisarParametrosAsync(parametrosDeAnaliseDto);            

            await ImprimirRelatorioAsync(retornoDaAnalise, parametrosDeAnaliseDto.TiposDeRelatorio);

            return retornoDaAnalise;
        }

        private async Task<AnaliseDto> AnalisarParametrosAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            Validar(parametrosDeAnaliseDto);

            Stopwatch diagnostico = new Stopwatch();
            diagnostico.Start();
            
            var retorno = await _analisador.ProcessarAsync(parametrosDeAnaliseDto.CaminhoDoArquivo, parametrosDeAnaliseDto.TamanhoDoBufferEmBytes);
            
            diagnostico.Stop();

            return new AnaliseDto(
                retorno.NomeDoArquivo,
                retorno.TamanhoDoArquivo.ToMegaBytesString(),
                retorno.CaminhoFisico,
                retorno.NumeroDeIteracoes,
                diagnostico.Elapsed.ToTimeFormat(),
                diagnostico.Elapsed.Divide(retorno.NumeroDeIteracoes).ToTimeFormat());
        }

        private void Validar(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            if (string.IsNullOrEmpty(parametrosDeAnaliseDto.CaminhoDoArquivo))
            {
                throw new ApplicationException("-Caminho do arquivo não pode estar vazio.");
            }

            if (_regex.IsMatch(parametrosDeAnaliseDto.CaminhoDoArquivo))
            {
                throw new ApplicationException("-Caminho do arquivo em um formato invalido.");
            }
        }

        private async Task ImprimirRelatorioAsync(AnaliseDto analiseDto, TiposDeRelatorio tiposDeRelatorio)
        {
            await _geradorDeLog.GerarLogAsync("Imprimindo os dados de annálise.");

            if (tiposDeRelatorio == TiposDeRelatorio.Tabela)
            {
                ImprimirTabelaAsync(analiseDto);
            }
            else
            {
                await ImprimirJsonAsync(analiseDto);
            }
        }

        private void ImprimirTabelaAsync(AnaliseDto analiseDto)
        {
            List<AnaliseDto> listaBaseTabela = new List<AnaliseDto>() {
                analiseDto
            };

            ConsoleTableBuilder
                .From(listaBaseTabela)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithColumn(
                "Nome Arquivo", 
                "Tamanho Arquivo", 
                "Caminho Físico", 
                "Número Iterações", 
                "Tempo Total Geração Arquivo", 
                "Tempo Médio Geração Arquivo")
                .WithTextAlignment(new Dictionary<int, TextAligntment>() {
                    {3, TextAligntment.Right},
                    {4, TextAligntment.Right},
                    {5, TextAligntment.Right}
                })
                .ExportAndWriteLine(TableAligntment.Left);
        }

        private async Task ImprimirJsonAsync(AnaliseDto analiseDto)
        {
            await _geradorDeLog.GerarLogAsync(JsonSerializer.Serialize(analiseDto));
        }
    }
}