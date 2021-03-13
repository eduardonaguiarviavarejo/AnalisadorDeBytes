using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.Dominio.Modelo
{
    public class Metricas : IModel
    {
        public Metricas(
            int numeroDeIteracoes, 
            TimeSpan tempoTotalgeracaoArquivo, 
            TimeSpan tempoMedioEscritaArquivo)
        {
            NumeroDeIteracoes = numeroDeIteracoes;
            TempoTotalgeracaoArquivo = tempoTotalgeracaoArquivo;
            TempoMedioEscritaArquivo = tempoMedioEscritaArquivo;
        }

        public int NumeroDeIteracoes { get; private set; }
        public TimeSpan TempoTotalgeracaoArquivo { get; private set; }
        public TimeSpan TempoMedioEscritaArquivo { get; private set; }
    }
}