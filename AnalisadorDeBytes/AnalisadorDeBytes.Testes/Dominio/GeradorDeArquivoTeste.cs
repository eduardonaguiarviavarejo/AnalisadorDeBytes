using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class GeradorDeArquivoTeste
    {
        private readonly IGeradorDeArquivo _GeradorDeArquivo;
        private readonly string _caminhoDoArquivo = @"c:\dev";
        private readonly int _tamanhoDoBuffer = 10240;        
        private readonly string _textoMock = "WebDriver doesn’t know how to do anything other than talk to the browser driver. As a result, you’ll need some sort of test framework to execute your tests, make assertions, and report test status. We’ll use NUnit, which is popular, free, and easy to learn and use.  There are many other test frameworks for the .NET platform. NUnit test cases are nothing more than class files added to the Visual Studio class library project. You can rename the initial “Class1.cs” file added to the project by default, or you can add another complete class by right-clicking the project and selecting Add Class.";
        public GeradorDeArquivoTeste()
        {
            _GeradorDeArquivo = new GeradorDeArquivo();
        }

        [Fact]
        public async Task ExecutarAsync_DevGerarArquivoAsync()
        {
            var infos = await _GeradorDeArquivo.ExecutarAsync(new GeradorDeArquivoComando(_caminhoDoArquivo, _tamanhoDoBuffer, _textoMock));

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
