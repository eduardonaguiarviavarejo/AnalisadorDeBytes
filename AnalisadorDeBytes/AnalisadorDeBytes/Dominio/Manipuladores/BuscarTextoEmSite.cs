using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class BuscarTextoEmSite : IBuscarTextoEmSite
    {
        public Task<BuscarTextoEmSiteResposta> ExecutarAsync(BuscarTextoEmSiteComandos comando)
        {
            throw new System.NotImplementedException();
        }
    }
}
