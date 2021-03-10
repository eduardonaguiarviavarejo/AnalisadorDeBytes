using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public interface IFallbackStrategy
    {
        Task<string> RetornarTexto();
    }
}