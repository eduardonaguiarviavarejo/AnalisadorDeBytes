using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Moq;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class ContadorDeBytesTeste
    {
        private readonly Mock<IContadorDeBytesWeb> _contadorDeBytesWeb = new Mock<IContadorDeBytesWeb>();
        private readonly IContadorDeBytes _contadorDeBytes;
        private readonly int _quantidadeBytesRetornada = 1024000;
        private readonly string _textoMock = "WebDriver doesn’t know how to do anything other than talk to the browser driver. As a result, you’ll need some sort of test framework to execute your tests, make assertions, and report test status. We’ll use NUnit, which is popular, free, and easy to learn and use.  There are many other test frameworks for the .NET platform. NUnit test cases are nothing more than class files added to the Visual Studio class library project. You can rename the initial “Class1.cs” file added to the project by default, or you can add another complete class by right-clicking the project and selecting Add Class.";

        public ContadorDeBytesTeste()
        {
            _contadorDeBytes = new ContadorDeBytes(_contadorDeBytesWeb.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task ExecutarAsync_DeveContarBytesAsync()
        {
            _contadorDeBytesWeb.Setup(x => x.ContarBytesPorTextoAsync(_textoMock))
                .ReturnsAsync(_quantidadeBytesRetornada);

            
            
            var resposta = await _contadorDeBytes.ExecutarAsync(new ContadorDeBytesComando(_textoMock));


            
            Assert.True(resposta.TamanhoDoTextoEmBytes > 0);
        }


        [Fact]
        public void ExecutarAsync_NaoDeveContarBytes() 
        {
            var resposta = _contadorDeBytes.ExecutarAsync(new ContadorDeBytesComando(string.Empty));
        }
    }
}
