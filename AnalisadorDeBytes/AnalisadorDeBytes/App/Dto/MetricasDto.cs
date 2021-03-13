using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.App.Dto
{
    public class MetricasDto : IDto
    {
        public MetricasDto(int numeroDeIteracoes, TimeSpan tempoTotalGeracaoArquivo, TimeSpan tempoMedioEscritaArquivo)
        {
            NumeroDeIteracoes = numeroDeIteracoes;
            TempoTotalGeracaoArquivo = tempoTotalGeracaoArquivo;
            TempoMedioEscritaArquivo = tempoMedioEscritaArquivo;
        }

        public int NumeroDeIteracoes { get; private set; }
        public TimeSpan TempoTotalGeracaoArquivo { get; private set; }
        public TimeSpan TempoMedioEscritaArquivo { get; private set; }
    }
}