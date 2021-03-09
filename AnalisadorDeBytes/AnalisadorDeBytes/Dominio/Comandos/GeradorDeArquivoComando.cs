using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class GeradorDeArquivoComando : IComando
    {
        public GeradorDeArquivoComando(
            string caminhoDoArquivo,
            decimal tamanhoDoBuffer,
            decimal tamanhoDoTexto,
            string texto)
        {
            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBuffer = tamanhoDoBuffer;
            TamanhoDoTexto = tamanhoDoTexto;
            Texto = texto;
        }

        public string CaminhoDoArquivo { get; private set; }
        public decimal TamanhoDoBuffer { get; private set; }
        public decimal TamanhoDoTexto { get; private set; }
        public string Texto { get; private set; }
    }
}
