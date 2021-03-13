using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Dominio;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class AnalisadorDeBytesTeste
    {
        private readonly string _caminhoFisicoArquivo = @"c:/dev";
        private readonly int _tamanhoMaximoBufferEmBytes = 1024000;
        private readonly string _siteWebParaBuscarTextos = "http://lerolero.com.br";
        private readonly string _textoMockado = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly int _quantidadeBytesRetornada = 1024000;

        private readonly IAnalisador _analisador;
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;
        private readonly IGeradorDeArquivo _geradorDeArquivo;
        private readonly Mock<IBuscadorDeTextoWeb> _buscadorWeb = new Mock<IBuscadorDeTextoWeb>();
        private readonly Mock<IContadorDeBytesWeb> _contadorDeBytesWeb = new Mock<IContadorDeBytesWeb>();



        public AnalisadorDeBytesTeste()
        {
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorWeb.Object);
            _contadorDeBytes = new ContadorDeBytes(_contadorDeBytesWeb.Object);
            _geradorDeArquivo = new GeradorDeArquivo();           
            _analisador = new Analisador();
            

            _buscadorWeb.Setup(x => x.Buscar())
                .ReturnsAsync(_textoMockado);

            _contadorDeBytesWeb.Setup(x => x.ContarBytesPorTextoAsync(_textoMockado))
                .ReturnsAsync(_quantidadeBytesRetornada);
        }





        [Fact]
        public async void ProcessarAsync_DeveriaGerarMetricas()
        {            
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.NotNull(infos.Metricas);
            Assert.True(infos.Metricas.NumeroDeIteracoes > 0);
            Assert.True(infos.Metricas.TempoMedioEscritaArquivo.TotalMilliseconds > 0);
            Assert.True(infos.Metricas.TempoTotalgeracaoArquivo.TotalMilliseconds > 0);
        }




        [Fact]
        public async void AnalyseAsync_DeveriaGerarMetricasComTamanhoDoBufferDiferente()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.NotNull(infos.Metricas);
            Assert.True(infos.Metricas.NumeroDeIteracoes > 0);
            Assert.True(infos.Metricas.TempoMedioEscritaArquivo.TotalMilliseconds > 0);
            Assert.True(infos.Metricas.TempoTotalgeracaoArquivo.TotalMilliseconds > 0);
        }




        [Fact]
        public async Task AnalyseAsync_DeveriaGerarMetricasFallbackBuscaAsync()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.NotNull(infos.Metricas);
            Assert.True(infos.Metricas.NumeroDeIteracoes > 0);
            Assert.True(infos.Metricas.TempoMedioEscritaArquivo.TotalMilliseconds > 0);
            Assert.True(infos.Metricas.TempoTotalgeracaoArquivo.TotalMilliseconds > 0);
        }




        [Fact]
        public async Task AnalyseAsync_DeveriaGerarMetricasFallbackContadorDeBytesAsync()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.NotNull(infos.Metricas);
            Assert.True(infos.Metricas.NumeroDeIteracoes > 0);
            Assert.True(infos.Metricas.TempoMedioEscritaArquivo.TotalMilliseconds > 0);
            Assert.True(infos.Metricas.TempoTotalgeracaoArquivo.TotalMilliseconds > 0);
        }




        [Fact]
        public async Task AnalyseAsync_NaoDeveriaGerarMetricasSemCaminhoArquivoAsync()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.NotNull(infos.Metricas);
            Assert.True(infos.Metricas.NumeroDeIteracoes > 0);
            Assert.True(infos.Metricas.TempoMedioEscritaArquivo.TotalMilliseconds > 0);
            Assert.True(infos.Metricas.TempoTotalgeracaoArquivo.TotalMilliseconds > 0);
        }
    }
}
