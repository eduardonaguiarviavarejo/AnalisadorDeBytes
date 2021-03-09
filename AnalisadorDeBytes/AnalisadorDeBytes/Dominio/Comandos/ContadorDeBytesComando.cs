using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Comandos
{
    public class ContadorDeBytesComando : IComando
    {
        public ContadorDeBytesComando(string textoDeEntrada)
        {
            TextoDeEntrada = textoDeEntrada;
        }

        public string TextoDeEntrada { get; private set; }
    }
}
