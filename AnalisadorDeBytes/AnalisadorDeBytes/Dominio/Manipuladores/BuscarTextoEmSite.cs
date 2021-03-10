using Abot2.Crawler;
using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class BuscarTextoEmSite : IBuscarTextoEmSite
    {
        private readonly IBuscadorWeb _buscadorWeb;        

        public BuscarTextoEmSite(IBuscadorWeb buscadorWeb)
        {
            _buscadorWeb = buscadorWeb;            
        }

        public async Task<BuscarTextoEmSiteResposta> ExecutarAsync(BuscarTextoEmSiteComandos comando)
        {
            var textoRetornado = await _buscadorWeb.Buscar(comando.UrlDoWebASerBuscada);

            return new BuscarTextoEmSiteResposta(textoRetornado);
        }
    }
}
