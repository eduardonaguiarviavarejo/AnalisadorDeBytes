using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class GeradorDeArquivoComando : IComando
    {
        public GeradorDeArquivoComando(
            string caminhoDoArquivo,
            int? tamanhoDoBufferEmBytes,
            string textoAnalisado)
        {
            
            if (string.IsNullOrEmpty(caminhoDoArquivo))
            {
                 throw new ApplicationException("-Caminho do arquivo não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(textoAnalisado))
            {
                throw new ApplicationException("-O texto não pode estar vazio.");                
            }

            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBufferEmBytes = tamanhoDoBufferEmBytes;
            TextoAnalisado = textoAnalisado;
        }

        public string CaminhoDoArquivo { get; private set; }
        public int? TamanhoDoBufferEmBytes { get; private set; }
        public string TextoAnalisado { get; private set; }
    }
}
