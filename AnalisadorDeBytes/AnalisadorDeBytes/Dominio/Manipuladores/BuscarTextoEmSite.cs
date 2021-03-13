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
        private readonly IBuscadorDeTextoWeb _buscadorWeb;        

        public BuscarTextoEmSite(IBuscadorDeTextoWeb buscadorWeb)
        {
            _buscadorWeb = buscadorWeb;
        }

        public async Task<BuscarTextoEmSiteResposta> ExecutarAsync(BuscarTextoEmSiteComandos comando)
        {
         
            var textoRetornado = await _buscadorWeb.Buscar();

            
            return new BuscarTextoEmSiteResposta(textoRetornado);
        }
    }
}
