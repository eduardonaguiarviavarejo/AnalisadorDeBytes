using AnalisadorDeBytes.IoC;
using System;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class BuscarTextoEmSiteComandos : IComando
    {
        public BuscarTextoEmSiteComandos(Uri urlDoWebASerBuscada)
        {
            UrlDoWebASerBuscada = urlDoWebASerBuscada;
        }

        public Uri UrlDoWebASerBuscada { get; private set; }
    }
}
