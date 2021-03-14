using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public interface IBuscadorDeTextoWeb
    {        
        Task<string> Buscar();
    }
}
