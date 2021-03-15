using AnalisadorDeBytes.Core.Componentes.GeradorDeLog;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class GeradorDeArquivoTeste : IDisposable
    {
        private readonly IGeradorDeArquivo _GeradorDeArquivo;
        private readonly string _caminhoDoArquivo = @"c:\data";
        private readonly int _tamanhoDoBuffer = 1000000;
        private readonly string _textoMock = "WebDriver doesn’t know how to do anything other than talk to the browser driver. As a result, you’ll need some sort of test framework to execute your tests, make assertions, and report test status. We’ll use NUnit, which is popular, free, and easy to learn and use.  There are many other test frameworks for the .NET platform. NUnit test cases are nothing more than class files added to the Visual Studio class library project. You can rename the initial “Class1.cs” file added to the project by default, or you can add another complete class by right-clicking the project and selecting Add Class.";
        private string arquivo = null;
        private readonly IGeradorDeLog _geradorDeLog;

        public GeradorDeArquivoTeste()
        {
            _geradorDeLog = new GeradorDeLog();
            _GeradorDeArquivo = new GeradorDeArquivo(_geradorDeLog);
        }

        public void Dispose()
        {
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
        }

        [Fact]
        public async Task ExecutarAsync_DeveGerarArquivoAsync()
        {
            var infos = await _GeradorDeArquivo.ExecutarAsync(new GeradorDeArquivoComando(_caminhoDoArquivo, null, _textoMock));

            Asserts(infos);
        }

        [Fact]
        public async Task ExecutarAsync_DeveGerarArquivoPassandoTamanhoBufferAsync()
        {
            var infos = await _GeradorDeArquivo.ExecutarAsync(new GeradorDeArquivoComando(_caminhoDoArquivo, _tamanhoDoBuffer, _textoMock));

            
            Asserts(infos);
        }


        private void Asserts(GeradorDeArquivoResposta infos)
        {
            Assert.NotNull(infos);
            Assert.NotNull(infos.CaminhoFisico);
            Assert.NotNull(infos.NomeDoArquivo);
            Assert.True(infos.TamanhoDoArquivo > 0);
            Assert.True(infos.NumeroDeIteracoes > 0);

            arquivo = Path.Combine(infos.CaminhoFisico, infos.NomeDoArquivo);
            Assert.True(File.Exists(arquivo));
        }
    }
}
