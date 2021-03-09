using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Dominio;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Moq;
using System;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class AnalisadorDeBytesTeste
    {
        private readonly string _caminhoFisicoArquivo = @"c:/dev";
        private readonly int _tamanhoMaximoBufferEmMegaBytes = 1;
        private readonly string _siteWebParaBuscarTextos = "http://lerolero.com.br";
        private readonly string _textoMockado = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly IAnalisador _analisador;
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;
        private readonly IGeradorDeArquivo _geradorDeArquivo;
        private readonly Mock<IBuscadorWeb> _buscadorWeb = new Mock<IBuscadorWeb>();


        public AnalisadorDeBytesTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorWeb.Object);
            _contadorDeBytes = new ContadorDeBytes();
            _geradorDeArquivo = new GeradorDeArquivo();
            _analisador = new Analisador(_buscarTextoEmSite, _contadorDeBytes, _geradorDeArquivo);
        }



        [Fact]
        public async void ProcessarAsync_DeveriaGerarMetricas()
        {
            _buscadorWeb.Setup(x => x.Buscar(new Uri(_siteWebParaBuscarTextos)))
                .ReturnsAsync(_textoMockado);


            var infos = await _analisador.ProcessarAsync(new Uri(_siteWebParaBuscarTextos), _caminhoFisicoArquivo, _tamanhoMaximoBufferEmMegaBytes);
        }



        [Fact]
        public async void AnalyseAsync_DeveriaGerarMetricasComTamanhoDoBufferDiferente()
        {
            var infos = await _analisador.ProcessarAsync(new Uri(_siteWebParaBuscarTextos), _caminhoFisicoArquivo, _tamanhoMaximoBufferEmMegaBytes);
        }



        [Fact]
        public void AnalyseAsync_DeveriaGerarMetricasFallbackBusca()
        {

        }



        [Fact]
        public void AnalyseAsync_DeveriaGerarMetricasFallbackContadorDeBytes()
        {

        }



        [Fact]
        public void AnalyseAsync_NaoDeveriaGerarMetricasSemCaminhoArquivo()
        {

        }
    }
}
