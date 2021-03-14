using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb
{
    public interface IContadorDeBytesWeb
    {
        Task<int> ContarBytesPorTextoAsync(string texto);
    }
}
