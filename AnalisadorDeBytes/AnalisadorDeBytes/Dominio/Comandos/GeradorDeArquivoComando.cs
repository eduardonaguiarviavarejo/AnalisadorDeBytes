using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class GeradorDeArquivoComando : IComando
    {
        public GeradorDeArquivoComando(
            string caminhoDoArquivo,
            int? tamanhoDoBufferEmBytes,
            string textoAnalisado)
        {
            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBufferEmBytes = tamanhoDoBufferEmBytes;
            TextoAnalisado = textoAnalisado;
        }

        public string CaminhoDoArquivo { get; private set; }
        public int? TamanhoDoBufferEmBytes { get; private set; }
        public string TextoAnalisado { get; private set; }
    }
}
