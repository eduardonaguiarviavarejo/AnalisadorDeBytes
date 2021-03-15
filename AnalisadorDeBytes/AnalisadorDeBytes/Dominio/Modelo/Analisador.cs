using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Core.Componentes.GeradorDeLog;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Manipuladores;
using AnalisadorDeBytes.Dominio.Servico;
using AnalisadorDeBytes.Dominio.Servico.Estrategia;
using AnalisadorDeBytes.Ioc;
using AnalisadorDeBytes.IoC;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Modelo
{
    public class Analisador : IAnalisador
    {
        private readonly IBuscadorDeTextoWeb _buscadorDeTextoWeb;
        private readonly IBuscarTextoEmSite _buscarTextoEmSite;
        private readonly IContadorDeBytes _contadorDeBytes;
        private readonly IGeradorDeArquivo _geradorDeArquivo;
        private readonly IContadorDeBytesWeb _contadorDeBytesWeb;
        private readonly IBuscadorDeTextoWebFallback _buscadorDeTextoWebFallback;
        private readonly IContadorDeBytesWebFallback _contadorDeBytesWebFallback;
        private readonly IGeradorDeLog _geradorDeLog;

        public Analisador()
        {
            _geradorDeLog = new GeradorDeLog();
            _buscadorDeTextoWebFallback = new GeradorDeTextoAleatorioFallback();
            _buscadorDeTextoWeb = new BuscarTextoServico(_buscadorDeTextoWebFallback, _geradorDeLog);
            _buscarTextoEmSite = new BuscarTextoEmSite(_buscadorDeTextoWeb);
            _contadorDeBytesWebFallback = new ContadorDeBytesFallback();
            _contadorDeBytesWeb = new ContarBytesServico(_contadorDeBytesWebFallback, _geradorDeLog);
            _contadorDeBytes = new ContadorDeBytes(_contadorDeBytesWeb);
            _geradorDeArquivo = new GeradorDeArquivo();
        }

        public async Task<InformacoesDaAnalise> ProcessarAsync(string caminhoDoArquivo, int? tamanhoDoBufferEmBytes)
        {
            var buscarTextoEmSiteResposta = await _buscarTextoEmSite.ExecutarAsync(new BuscarTextoEmSiteComandos());

            
            var contadorDeBytesComando = new ContadorDeBytesComando(buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);
            var contadorDeBytesResposta = await _contadorDeBytes.ExecutarAsync(contadorDeBytesComando);

            
            var geradorDeArquivoComando = new GeradorDeArquivoComando(
                caminhoDoArquivo,
                tamanhoDoBufferEmBytes,
                buscarTextoEmSiteResposta.TextoRecuperadoDaWeb);

            
            var geradorDeArquivoResposta = await _geradorDeArquivo.ExecutarAsync(geradorDeArquivoComando);

            
            return new InformacoesDaAnalise(
                geradorDeArquivoResposta.NomeDoArquivo,
                geradorDeArquivoResposta.TamanhoDoArquivo,
                geradorDeArquivoResposta.CaminhoFisico,
                geradorDeArquivoResposta.NumeroDeIteracoes);
        }
    }
}