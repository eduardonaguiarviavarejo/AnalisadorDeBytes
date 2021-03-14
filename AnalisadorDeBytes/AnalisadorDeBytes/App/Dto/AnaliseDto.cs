using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.App.Dto
{
    public class AnaliseDto : IDto
    {
        public AnaliseDto(
        string nomeDoArquivo,
        string tamanhoDoArquivo,
        string caminhoFisico,
        int numeroDeIteracoes, 
        string tempoTotalGeracaoArquivo, 
        string tempoMedioEscritaArquivo)
        {
            NomeDoArquivo = nomeDoArquivo;
            TamanhoDoArquivo = tamanhoDoArquivo;
            CaminhoFisico = caminhoFisico;
            NumeroDeIteracoes = numeroDeIteracoes;
            TempoTotalGeracaoArquivo = tempoTotalGeracaoArquivo;
            TempoMedioEscritaArquivo = tempoMedioEscritaArquivo;
        }



        public string NomeDoArquivo { get; private set; }
        public string TamanhoDoArquivo { get; private set; }
        public string CaminhoFisico { get; private set; }
        public int NumeroDeIteracoes { get; private set; }
        public string TempoTotalGeracaoArquivo { get; private set; }
        public string TempoMedioEscritaArquivo { get; private set; }
    }
}
