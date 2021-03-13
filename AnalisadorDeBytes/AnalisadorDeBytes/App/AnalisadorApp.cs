using AnalisadorDeBytes.App.Dto;
using AnalisadorDeBytes.App.Mapeamento;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using ConsoleTableExt;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.App
{
    public class AnalisadorApp : IAnalisadorApp
    {
        private readonly IAnalisador _analisador;
        private readonly IGeradorDeLog _geradorDeLog;

        public AnalisadorApp(
            IAnalisador analisador,
            IGeradorDeLog geradorDeLog)
        {
            _analisador = analisador;
            _geradorDeLog = geradorDeLog;
        }

        public async Task AnalisarAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            var retornoDaAnalise = await AnalisarParametrosAsync(parametrosDeAnaliseDto);

            await ImprimirRelatorioAsync(retornoDaAnalise, parametrosDeAnaliseDto.TiposDeRelatorio);
        }

        private async Task<AnaliseDto> AnalisarParametrosAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            return await new AnaliseMap().ModelToDtoAsync(await _analisador.ProcessarAsync(parametrosDeAnaliseDto.CaminhoDoArquivo, parametrosDeAnaliseDto.TamanhoDoBufferEmBytes));
        }

        private async Task ImprimirRelatorioAsync(AnaliseDto analiseDto, TiposDeRelatorio tiposDeRelatorio)
        {
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
                .ExportAndWriteLine(TableAligntment.Center);
        }

        private async Task ImprimirJsonAsync(AnaliseDto analiseDto)
        {
            await _geradorDeLog.GerarLogAsync(JsonSerializer.Serialize(analiseDto));
        }
    }
}