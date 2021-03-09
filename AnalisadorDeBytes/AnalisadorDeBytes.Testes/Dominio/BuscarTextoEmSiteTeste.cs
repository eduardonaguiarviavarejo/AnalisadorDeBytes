using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Moq;
using System;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class BuscarTextoEmSiteTeste
    {
        private readonly string _siteParaBuscarTextos = "http://lerolero.com.br";
        private readonly string _siteParaBuscarTextosFake = "http://lerolero22.com.br";
        private readonly string _textoMockado = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly Mock<IBuscadorWeb> _buscadorWeb = new Mock<IBuscadorWeb>();


        public BuscarTextoEmSiteTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorWeb.Object);
        }

        public async void ExecutarAsync_DeveriaBuscarTextosNoSite()
        {
            _buscadorWeb.Setup(x => x.Buscar(new Uri(_siteParaBuscarTextos)))
                .ReturnsAsync(_textoMockado);


            var resposta = await _buscarTextoEmSite
                .ExecutarAsync(new BuscarTextoEmSiteComandos(new Uri(_siteParaBuscarTextos)));

                                   
            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }


        public async void ExecutarAsync_NaoDeveriaBuscarTextosNoSiteSiteInexistente()
        {
            var resposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos(new Uri(_siteParaBuscarTextosFake)));


            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }
    }
}
