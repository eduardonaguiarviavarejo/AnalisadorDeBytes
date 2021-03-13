using AnalisadorDeBytes.App.Dto;
using AnalisadorDeBytes.Dominio;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.App.Mapeamento
{
    public class AnaliseMap : IMap<AnaliseDto, InformacoesDaAnalise>
    {
        public Task<InformacoesDaAnalise> DtoToModelAsync(AnaliseDto dto)
        {
            return Task.Run(() =>
            {
                return new InformacoesDaAnalise(
                    dto.NomeDoArquivo,
                    dto.TamanhoDoArquivo,
                    dto.CaminhoFisico,
                    new Metricas(
                        dto.Metricas.NumeroDeIteracoes, dto.Metricas.TempoTotalGeracaoArquivo, dto.Metricas.TempoMedioEscritaArquivo));
            });
        }



        public Task<AnaliseDto> ModelToDtoAsync(InformacoesDaAnalise model)
        {
            return Task.Run(() =>
            {
                return new AnaliseDto(
                 model.NomeDoArquivo,
                 model.TamanhoDoArquivo,
                 model.CaminhoFisico,
                 new MetricasDto(
                     model.Metricas.NumeroDeIteracoes, 
                     model.Metricas.TempoTotalgeracaoArquivo, 
                     model.Metricas.TempoTotalgeracaoArquivo));
            });
        }
    }
}
