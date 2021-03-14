using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.App.Dto
{
    public class AnaliseDto : IDto
    {
        public AnaliseDto(
        string nomeDoArquivo,
        decimal tamanhoDoArquivo,
        string caminhoFisico,
        int numeroDeIteracoes, 
        TimeSpan tempoTotalGeracaoArquivo, 
        TimeSpan tempoMedioEscritaArquivo)
        {
            NomeDoArquivo = nomeDoArquivo;
            TamanhoDoArquivo = tamanhoDoArquivo;
            CaminhoFisico = caminhoFisico;
            NumeroDeIteracoes = numeroDeIteracoes;
            TempoTotalGeracaoArquivo = tempoTotalGeracaoArquivo;
            TempoMedioEscritaArquivo = tempoMedioEscritaArquivo;
        }



        public string NomeDoArquivo { get; private set; }
        public decimal TamanhoDoArquivo { get; private set; }
        public string CaminhoFisico { get; private set; }
        public int NumeroDeIteracoes { get; private set; }
        public TimeSpan TempoTotalGeracaoArquivo { get; private set; }
        public TimeSpan TempoMedioEscritaArquivo { get; private set; }
    }
}
