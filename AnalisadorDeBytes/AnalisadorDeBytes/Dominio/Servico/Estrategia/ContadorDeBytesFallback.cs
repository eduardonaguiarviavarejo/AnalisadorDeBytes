using AnalisadorDeBytes.Ioc;
using System.Text;

namespace AnalisadorDeBytes.Dominio.Servico.Estrategia
{
    public class ContadorDeBytesFallback : IContadorDeBytesWebFallback
    {
        public int ContarBytesDoTexto(string texto)
        {
            return ASCIIEncoding.Unicode.GetByteCount(texto);
        }
    }
}
