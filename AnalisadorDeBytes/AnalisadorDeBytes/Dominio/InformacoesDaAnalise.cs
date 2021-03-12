using AnalisadorDeBytes.Dominio.Respostas;

namespace AnalisadorDeBytes.Dominio
{
    public class InformacoesDaAnalise : GeradorDeArquivoResposta
    {
        public InformacoesDaAnalise(string nomeDoArquivo, decimal tamanhoDoArquivo, string caminhoFisico, Metricas metricas) : base(nomeDoArquivo, tamanhoDoArquivo, caminhoFisico, metricas)
        {
        }
    }
}