using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class ContadorDeBytesTeste
    {
        private readonly IContadorDeBytes _contadorDeBytes;

        public ContadorDeBytesTeste()
        {
            _contadorDeBytes = new ContadorDeBytes();
        }

        [Fact]
        public void ExecutarAsync_DeveContarBytes()
        {
            var resposta = _contadorDeBytes.ExecutarAsync(new ContadorDeBytesComando("skdlskdfl"));
        }


        [Fact]
        public void ExecutarAsync_NaoDeveContarBytes() 
        {
            var resposta = _contadorDeBytes.ExecutarAsync(new ContadorDeBytesComando("skdlskdfl"));
        }
    }
}
