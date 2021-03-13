using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;

namespace AnalisadorDeBytes.Dominio.Estrategia.ContadorDeBytesFallback
{
    public class ContadorDeBytesFallback : IContadorDeBytesWebFallback
    {
        public int ContarBytesDoTexto(string texto)
        {
            throw new System.NotImplementedException();
        }
    }
}
