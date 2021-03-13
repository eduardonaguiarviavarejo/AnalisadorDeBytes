using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Core.Componentes.GeradorDeLog;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Estrategia;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio
{
    public class Analisador : IAnalisador
    {
        private const int TAMANHODOBUFFER = 1048576;

        private IBuscadorDeTextoWeb _buscadorDeTextoWeb;
        private IBuscarTextoEmSite _buscarTextoEmSite;
        private IContadorDeBytes _contadorDeBytes;
        private IGeradorDeArquivo _geradorDeArquivo;
        private IContadorDeBytesWeb _contadorDeBytesWeb;
        private IBuscadorDeTextoWebFallback _buscadorDeTextoWebFallback;
        private IContadorDeBytesWebFallback _contadorDeBytesWebFallback;
        private IGeradorDeLog _geradorDeLog;

        public Analisador()
        {
            _geradorDeLog = new GeradorDeLog();
            _buscadorDeTextoWebFallback = new GeradorDeTextoAleatorioFallback();
            _buscadorDeTextoWeb = new BuscadorDeTextoWeb(_buscadorDeTextoWebFallback, _geradorDeLog);
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorDeTextoWeb);
            _contadorDeBytesWeb = new ContadorDeBytesWeb(_contadorDeBytesWebFallback, _geradorDeLog);
            _contadorDeBytes = new ContadorDeBytes(_contadorDeBytesWeb);
            _geradorDeArquivo = new GeradorDeArquivo();
        }

        public async Task<InformacoesDaAnalise> ProcessarAsync(string caminhoDoArquivo, int tamanhoDoBuffer = TAMANHODOBUFFER)
        {
            var buscarTextoEmSiteResposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos());

            
            var contadorDeBytesComando = new ContadorDeBytesComando(buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);
            var contadorDeBytesResposta = await _contadorDeBytes.ExecutarAsync(contadorDeBytesComando);

            
            var geradorDeArquivoComando = new GeradorDeArquivoComando(
                caminhoDoArquivo,
                tamanhoDoBuffer,
                buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);

            
            var geradorDeArquivoResposta = await _geradorDeArquivo.ExecutarAsync(geradorDeArquivoComando);

            
            return new InformacoesDaAnalise(
                geradorDeArquivoResposta.NomeDoArquivo,
                geradorDeArquivoResposta.TamanhoDoArquivo,
                geradorDeArquivoResposta.CaminhoFisico,
                geradorDeArquivoResposta.Metricas);
        }
    }
}