using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IBuscadorDeTextoWebFallback
    {
        Task<string> BuscarTextoAleatorio();
    }
}