using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Respostas
{
    public class GeradorDeArquivoResposta : IResposta
    {
        public GeradorDeArquivoResposta(
        string nomeDoArquivo,
        decimal tamanhoDoArquivo,
        string caminhoFisico, 
        int numeroDeIteracoes)
        {
            NomeDoArquivo = nomeDoArquivo;
            TamanhoDoArquivo = tamanhoDoArquivo;
            CaminhoFisico = caminhoFisico;
            NumeroDeIteracoes = numeroDeIteracoes;
        }

        public string NomeDoArquivo { get; private set; }
        public decimal TamanhoDoArquivo { get; private set; }
        public string CaminhoFisico { get; private set; }
        public int NumeroDeIteracoes { get; private set; }
    }
}
