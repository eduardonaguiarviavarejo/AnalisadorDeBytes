using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio
{
    public class Analisador : IAnalisador
    {
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;

        public Analisador(IBuscarTextoEmSite buscarTextoEmSite, IContadorDeBytes contadorDeBytes)
        {
            _buscarTextoEmSite = buscarTextoEmSite;
            _contadorDeBytes = contadorDeBytes;
        }

        public async Task<InformacoesDaAnalise> ProcessarAsync(string caminhoDoArquivo, int tamanhoDoBuffer = 1)
        {
            var buscarTextoEmSiteComandos = new BuscarTextoEmSiteComandos(new Uri("http://www.lerolero.com.br"));
            var buscarTextoEmSiteResposta = await _buscarTextoEmSite.ExecutarAsync(buscarTextoEmSiteComandos);

            var contadorDeBytesComando = new ContadorDeBytesComando(buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);
            var contadorDeBytesResposta = await _contadorDeBytes.ExecutarAsync(contadorDeBytesComando);


            return new InformacoesDaAnalise();
        }
    }
}
