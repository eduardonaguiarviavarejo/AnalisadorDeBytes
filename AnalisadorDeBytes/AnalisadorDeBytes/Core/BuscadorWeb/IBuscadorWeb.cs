using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public interface IBuscadorWeb
    {
       Task<string> Buscar(Uri urlDoSiteASerBuscado);
    }
}
