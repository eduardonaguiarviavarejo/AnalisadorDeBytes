using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Respostas
{
    public class ContadorDeBytesResposta : IResposta
    {
        public ContadorDeBytesResposta(int tamanhoDoTextoEmBytes)
        {
            TamanhoDoTextoEmBytes = tamanhoDoTextoEmBytes;
        }

        public int TamanhoDoTextoEmBytes { get; private set; }
    }
}
