using AnalisadorDeBytes.App.Dto;
using AnalisadorDeBytes.App.Mapeamento;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.App
{
    public class AnalisadorApp : IAnalisadorApp
    {
        private readonly IAnalisador _analisador;




        public AnalisadorApp(IAnalisador analisador)
        {
            _analisador = analisador;
        }




        public async Task AnalisarAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            
            var retornoDaAnalise = await Analisar(parametrosDeAnaliseDto);
            
            
            
            await ImprimirRelatorio(retornoDaAnalise, parametrosDeAnaliseDto.TiposDeRelatorio);
        }




        private async Task<AnaliseDto> Analisar(ParametrosDeAnaliseDto parametrosDeAnaliseDto)
        {
            return await new AnaliseMap().ModelToDtoAsync(await _analisador.ProcessarAsync(parametrosDeAnaliseDto.CaminhoDoArquivo, parametrosDeAnaliseDto.TamanhoDoBufferEmBytes));
        }




        private Task ImprimirRelatorio(AnaliseDto analiseDto, TiposDeRelatorio tiposDeRelatorio)
        {
            return Task.Run(async () =>
            {
                if (tiposDeRelatorio == TiposDeRelatorio.Tabela)
                {
                    await ImprimirTabela(analiseDto);
                }
                else
                {
                    await ImprimirJson(analiseDto);
                }
            });
        }




        private Task ImprimirTabela(AnaliseDto analiseDto)
        {
            throw new NotImplementedException();
        }




        private Task ImprimirJson(AnaliseDto analiseDto)
        {
            throw new NotImplementedException();
        }
    }
}
