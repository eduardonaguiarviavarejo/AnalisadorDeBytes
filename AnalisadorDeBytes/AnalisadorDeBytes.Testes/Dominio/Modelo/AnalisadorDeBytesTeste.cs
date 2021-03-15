using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Core.Componentes.GeradorDeLog;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class AnalisadorDeBytesTeste : IDisposable
    {
        private readonly string _caminhoFisicoArquivo = @"c:\data";
        private readonly int _tamanhoMaximoBufferEmBytes = 5024000;
        private readonly string _textoMockado = "O fluxo deve se repetir até que o arquivo tenha o tamanho de 100MB como tamanho padrão";
        private readonly int _quantidadeBytesRetornada = 1024000;
        private string arquivo = null;

        private readonly IAnalisador _analisador;
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;
        private readonly IGeradorDeArquivo _geradorDeArquivo;
        private readonly Mock<IBuscadorDeTextoWeb> _buscadorWeb = new Mock<IBuscadorDeTextoWeb>();
        private readonly Mock<IContadorDeBytesWeb> _contadorDeBytesWeb = new Mock<IContadorDeBytesWeb>();
        private readonly IGeradorDeLog _geradorDeLog;

        public AnalisadorDeBytesTeste()
        {
            _geradorDeLog = new GeradorDeLog();
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorWeb.Object);
            _contadorDeBytes = new ContadorDeBytes(_contadorDeBytesWeb.Object);
            _geradorDeArquivo = new GeradorDeArquivo(_geradorDeLog);
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

            Asserts(infos);
        }

        [Fact]
        public async void AnalyseAsync_DeveriaGerarMetricasComTamanhoDoBufferDiferente()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Asserts(infos);
        }

        [Fact]
        public async Task AnalyseAsync_DeveriaGerarMetricasFallbackBuscaAsync()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Asserts(infos);
        }

        [Fact]
        public async Task AnalyseAsync_DeveriaGerarMetricasFallbackContadorDeBytesAsync()
        {
            var infos = await _analisador.ProcessarAsync(_caminhoFisicoArquivo, _tamanhoMaximoBufferEmBytes);

            Asserts(infos);
        }

        private void Asserts(AnalisadorDeBytes.Dominio.InformacoesDaAnalise infos)
        {
            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.True(infos.NumeroDeIteracoes > 0);

            arquivo = Path.Combine(infos.CaminhoFisico, infos.NomeDoArquivo);
            Assert.True(File.Exists(arquivo));
        }


        [Fact]
        public async Task AnalyseAsync_NaoDeveriaGerarMetricasSemCaminhoArquivoAsync()
        {
            ApplicationException exception = await Assert.ThrowsAsync<ApplicationException>(()=> _analisador.ProcessarAsync(null, _tamanhoMaximoBufferEmBytes));

            Assert.Equal("-Caminho do arquivo não pode estar vazio.", exception.Message);
        }


        public void Dispose()
        {
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
        }
    }
}
