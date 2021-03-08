using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.IoC;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio
{
    public class AnalisadorDeBytes
    {
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;

        public AnalisadorDeBytes(IBuscarTextoEmSite buscarTextoEmSite)
        {
            _buscarTextoEmSite = buscarTextoEmSite;
        }

        public async Task<InformacoesDaAnalise> AnalyseAsync(string caminhoDoArquivo, int tamanhoDoBuffer = 1)
        {
            var buscarTextoEmSiteComandos = new BuscarTextoEmSiteComandos(new Uri("http://www.lerolero.com.br"));
            var buscarTextoEmSiteResposata = await _buscarTextoEmSite.ExecutarAsync(buscarTextoEmSiteComandos);

            return new InformacoesDaAnalise();
        }
    }
}
