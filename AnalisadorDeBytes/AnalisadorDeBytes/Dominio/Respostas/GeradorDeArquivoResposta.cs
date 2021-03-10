using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Respostas
{
    public class GeradorDeArquivoResposta : IResposta
    {
        public GeradorDeArquivoResposta(
        string nomeDoArquivo,
        decimal tamanhoDoArquivo,
        string caminhoFisico,
        Metricas metricas)
        {
            NomeDoArquivo = nomeDoArquivo;
            TamanhoDoArquivo = tamanhoDoArquivo;
            CaminhoFisico = caminhoFisico;
            Metricas = metricas;
        }

        public string NomeDoArquivo { get; private set; }
        public decimal TamanhoDoArquivo { get; private set; }
        public string CaminhoFisico { get; private set; }
        public Metricas Metricas { get; private set; }
    }
}
