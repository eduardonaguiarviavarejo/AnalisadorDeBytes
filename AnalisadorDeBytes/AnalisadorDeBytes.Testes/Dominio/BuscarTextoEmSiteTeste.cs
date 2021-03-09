using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using System;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class BuscarTextoEmSiteTeste
    {
        private readonly string _siteParaBuscarTextos = "http://lerolero.com.br";
        private readonly string _siteParaBuscarTextosFake = "http://lerolero22.com.br";
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;


        public BuscarTextoEmSiteTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite();
        }

        public async void ExecutarAsync_DeveriaBuscarTextosNoSite()
        {
            var resposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos(new Uri(_siteParaBuscarTextos)));
                       
            
            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }


        public async void ExecutarAsync_NaoDeveriaBuscarTextosNoSiteSiteInexistente()
        {
            var resposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos(new Uri(_siteParaBuscarTextosFake)));


            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }
    }
}
