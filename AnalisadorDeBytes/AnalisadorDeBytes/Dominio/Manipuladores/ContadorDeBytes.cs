using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class ContadorDeBytes : IContadorDeBytes
    {
        private readonly IContadorDeBytesWeb _contadorDeBytesWeb;

        public ContadorDeBytes(IContadorDeBytesWeb contadorDeBytesWeb)
        {
            _contadorDeBytesWeb = contadorDeBytesWeb;
        }



        public async Task<ContadorDeBytesResposta> ExecutarAsync(ContadorDeBytesComando comando)
        {
            return new ContadorDeBytesResposta(await _contadorDeBytesWeb.ContarBytesPorTextoAsync(comando.TextoDeEntrada));
        }
    }
}
