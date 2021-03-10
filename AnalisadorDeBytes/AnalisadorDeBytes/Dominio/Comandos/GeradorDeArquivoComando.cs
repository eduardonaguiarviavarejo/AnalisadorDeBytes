using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class GeradorDeArquivoComando : IComando
    {
        public GeradorDeArquivoComando(
            string caminhoDoArquivo,
            int tamanhoDoBuffer,
            decimal tamanhoDoTexto,
            string textoAnalisado)
        {
            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBuffer = tamanhoDoBuffer;
            TamanhoDoTexto = tamanhoDoTexto;
            TextoAnalisado = textoAnalisado;
        }

        public string CaminhoDoArquivo { get; private set; }
        public int TamanhoDoBuffer { get; private set; } 
        public decimal TamanhoDoTexto { get; private set; }
        public string TextoAnalisado { get; private set; }
    }
}
