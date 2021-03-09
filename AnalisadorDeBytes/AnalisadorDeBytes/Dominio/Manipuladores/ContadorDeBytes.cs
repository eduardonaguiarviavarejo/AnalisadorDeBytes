using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class ContadorDeBytes : IContadorDeBytes
    {
        public Task<ContadorDeBytesResposta> ExecutarAsync(ContadorDeBytesComando comando)
        {
            throw new System.NotImplementedException();
        }
    }
}
