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
        private readonly string _textoMockado = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly Mock<IBuscadorDeTextoWeb> _buscadorWeb = new Mock<IBuscadorDeTextoWeb>();

        public BuscarTextoEmSiteTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorWeb.Object);
        }

        public async void ExecutarAsync_DeveriaBuscarTextosNoSite()
        {
            _buscadorWeb.Setup(x => x.Buscar())
              .ReturnsAsync(_textoMockado);

            var resposta = await _buscarTextoEmSite
              .ExecutarAsync(new BuscarTextoEmSiteComandos());

            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }

        public async void ExecutarAsync_NaoDeveriaBuscarTextosNoSiteSiteInexistente()
        {
            var resposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos());

            Assert.NotNull(resposta.TextoRecuperadoDaWeb);
        }
    }
}