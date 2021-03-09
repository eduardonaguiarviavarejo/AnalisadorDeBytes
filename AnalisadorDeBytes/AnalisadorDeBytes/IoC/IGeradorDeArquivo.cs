using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;

namespace AnalisadorDeBytes.IoC
{
    public interface IGeradorDeArquivo : IManipulador<GeradorDeArquivoComando, GeradorDeArquivoResposta>
    {
    }
}
