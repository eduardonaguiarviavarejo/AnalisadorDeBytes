using AnalisadorDeBytes.Dominio;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
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
        private readonly string _texto = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly Analisador _analisador;
        private readonly Mock<IBuscarTextoEmSite> _buscarTextoEmSite = new Mock<IBuscarTextoEmSite>();

        public AnalisadorDeBytesTeste()
        {
            _analisador = new Analisador(_buscarTextoEmSite.Object);
        }

        [Fact]
        public async void ProcessarAsync_DeveriaGerarMetricas()
        {
            _buscarTextoEmSite.Setup(x => x.ExecutarAsync(new BuscarTextoEmSiteComandos(new Uri("http://www.lerolero.com.br"))))
                .ReturnsAsync(new BuscarTextoEmSiteResposta(_texto));

        }



        [Fact]
        public async void AnalyseAsync_DeveriaGerarMetricasComTamanhoDoBufferDiferente()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, 5);
        }



        [Fact]
        public void AnalyseAsync_DeveriaGerarMetricasFallbackCrawl()
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
