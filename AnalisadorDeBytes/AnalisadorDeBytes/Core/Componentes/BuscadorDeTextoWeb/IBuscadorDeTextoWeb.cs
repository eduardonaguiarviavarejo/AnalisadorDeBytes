using Abot2.Crawler;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public interface IBuscadorDeTextoWeb
    {
       Task<string> Buscar(Uri urlDoSiteASerBuscado);
    }
}
