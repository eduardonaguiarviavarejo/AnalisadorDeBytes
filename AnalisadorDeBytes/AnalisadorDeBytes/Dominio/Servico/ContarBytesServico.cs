using AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Ioc;
using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Servico
{
    public class ContarBytesServico : IContadorDeBytesWeb
    {
        private const string SITEWEB = "https://mothereff.in/byte-counter";
        private readonly IContadorDeBytesWebFallback _contadorDeBytesWebFallback;
        private readonly IGeradorDeLog _geradorDeLog;

        public ContarBytesServico(
            IContadorDeBytesWebFallback contadorDeBytesWebFallback,
            IGeradorDeLog geradorDeLog)
        {
            _contadorDeBytesWebFallback = contadorDeBytesWebFallback;
            _geradorDeLog = geradorDeLog;
        }

        public async Task<int> ContarBytesPorTextoAsync(string texto)
        {

            Browser _browser;

            await _geradorDeLog.GerarLogAsync($"Iniciando crawler para contagem de bytes.");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            _browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true

            });            

            try
            {
                using (var paginaBuscada = await _browser.NewPageAsync())
                {
                    await paginaBuscada.GoToAsync($"{SITEWEB}#{texto}");

                    await _geradorDeLog.GerarLogAsync($"Iniciando contagem de bytes.");

                    string valorEmBytesCalculado = await paginaBuscada.EvaluateExpressionAsync<string>("document.getElementById('bytes').textContent");

                    return int.Parse(valorEmBytesCalculado.Replace("bytes", ""));
                }

            }
            catch (ApplicationException ex)
            {

                await _geradorDeLog.GerarLogAsync($"Erro: {ex.Message}");

                await _geradorDeLog.GerarLogAsync($"Executando estratégia de fallback.");

                return _contadorDeBytesWebFallback.ContarBytesDoTexto(texto);
            }
        }
    }
}