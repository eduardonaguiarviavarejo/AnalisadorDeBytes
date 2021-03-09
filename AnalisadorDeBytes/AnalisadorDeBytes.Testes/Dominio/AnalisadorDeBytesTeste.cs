using AnalisadorDeBytes.Dominio;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class AnalisadorDeBytesTeste
    {
        private readonly string _caminhoFisicoArquivo = @"c:/dev";
        private readonly int _tamanhoMaximoBufferEmMegaBytes = 1;
        private readonly string _texto = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly IAnalisador _analisador;
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;


        public AnalisadorDeBytesTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite();
            _contadorDeBytes = new ContadorDeBytes();
            _analisador = new Analisador(_buscarTextoEmSite, _contadorDeBytes);
        }

        [Fact]
        public async void ProcessarAsync_DeveriaGerarMetricas()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmMegaBytes);
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
