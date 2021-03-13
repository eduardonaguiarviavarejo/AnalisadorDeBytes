using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using System.Text;

namespace AnalisadorDeBytes.Dominio.Estrategia.ContadorDeBytesFallback
{
    public class ContadorDeBytesFallback : IContadorDeBytesWebFallback
    {
        public int ContarBytesDoTexto(string texto)
        {
            return ASCIIEncoding.Unicode.GetByteCount(texto);
        }
    }
}
