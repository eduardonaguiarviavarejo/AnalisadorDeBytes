using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.App.Dto
{
    public class AnaliseDto : IDto
    {
        public AnaliseDto(
        string nomeDoArquivo,
        decimal tamanhoDoArquivo,
        string caminhoFisico,
        MetricasDto metricas)
        {
            NomeDoArquivo = nomeDoArquivo;
            TamanhoDoArquivo = tamanhoDoArquivo;
            CaminhoFisico = caminhoFisico;
            Metricas = metricas;
        }

        public string NomeDoArquivo { get; private set; }
        public decimal TamanhoDoArquivo { get; private set; }
        public string CaminhoFisico { get; private set; }
        public MetricasDto Metricas { get; private set; }
    }
}
