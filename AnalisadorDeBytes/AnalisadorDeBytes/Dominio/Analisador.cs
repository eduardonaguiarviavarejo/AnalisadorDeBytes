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
        private readonly IGeradorDeArquivo _geradorDeArquivo;



        public Analisador(
            IBuscarTextoEmSite buscarTextoEmSite, 
            IContadorDeBytes contadorDeBytes, 
            IGeradorDeArquivo geradorDeArquivo)
        {
            _buscarTextoEmSite = buscarTextoEmSite;
            _contadorDeBytes = contadorDeBytes;
            _geradorDeArquivo = geradorDeArquivo;
        }




        public async Task<InformacoesDaAnalise> ProcessarAsync(Uri paginaWebParaBuscaDosTextos, string caminhoDoArquivo, int tamanhoDoBuffer = 1)
        {
            var buscarTextoEmSiteComandos = new BuscarTextoEmSiteComandos(paginaWebParaBuscaDosTextos);
            var buscarTextoEmSiteResposta = await _buscarTextoEmSite.ExecutarAsync(buscarTextoEmSiteComandos);



            var contadorDeBytesComando = new ContadorDeBytesComando(buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);
            var contadorDeBytesResposta = await _contadorDeBytes.ExecutarAsync(contadorDeBytesComando);



            var geradorDeArquivoComando = new GeradorDeArquivoComando(
                caminhoDoArquivo, 
                tamanhoDoBuffer, 
                contadorDeBytesResposta.TamanhoDoTextoEmBytes, 
                buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);

            var geradorDeArquivoResposta = _geradorDeArquivo.ExecutarAsync(geradorDeArquivoComando);

            return new InformacoesDaAnalise();
        }
    }
}
