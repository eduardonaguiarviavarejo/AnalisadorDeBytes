using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public interface IBuscadorDeTextoWebFallback
    {
        Task<string> BuscarTextoAleatorio();
    }
}