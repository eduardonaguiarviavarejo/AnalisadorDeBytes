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
        private readonly string _caminhoDoAruqivo;
        private readonly int _tamanhoDoBuffer;
        private readonly decimal _tamanhoDoTexto;
        private readonly string _texto;
        public GeradorDeArquivoTeste()
        {
            _GeradorDeArquivo = new GeradorDeArquivo();
        }

        [Fact]
        public async Task ExecutarAsync_DevGerarArquivoAsync()
        {
            var resposta = await _GeradorDeArquivo.ExecutarAsync(new GeradorDeArquivoComando(_caminhoDoAruqivo, _tamanhoDoBuffer, _tamanhoDoTexto, _texto));
        }
    }
}
