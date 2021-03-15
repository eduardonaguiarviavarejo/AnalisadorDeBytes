using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;

namespace AnalisadorDeBytes.IoC
{
    public interface IContadorDeBytes : IManipulador<ContadorDeBytesComando, ContadorDeBytesResposta>
    {
    }
}
