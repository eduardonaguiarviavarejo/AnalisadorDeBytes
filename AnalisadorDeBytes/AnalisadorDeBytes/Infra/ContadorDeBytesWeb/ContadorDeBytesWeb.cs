using AnalisadorDeBytes.Core.Componentes.Log;
using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb
{
    public class ContadorDeBytesWeb : IContadorDeBytesWeb
    {
        private readonly IContadorDeBytesWebFallback _contadorDeBytesWebFallback;
        private readonly IGeradorDeLog _geradorDeLog;



        public ContadorDeBytesWeb(
            IContadorDeBytesWebFallback contadorDeBytesWebFallback, 
            IGeradorDeLog geradorDeLog)
        {
            _contadorDeBytesWebFallback = contadorDeBytesWebFallback;
            _geradorDeLog = geradorDeLog;
        }




        public async Task<int> ContarBytesPorTextoAsync(string texto)
        {
            try
            {
                Browser _browser;


                await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);


                _browser = Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true

                }).Result;

                
                using (var paginaBuscada = await _browser.NewPageAsync())
                {
                    await paginaBuscada.GoToAsync($"https://mothereff.in/byte-counter#{texto}");


                    await _geradorDeLog.GerarLog($"Iniciando contagem de bytes.");


                    string valorEmBytesCalculado = await paginaBuscada.EvaluateExpressionAsync<string>("document.getElementById('bytes').textContent");



                    return int.Parse(valorEmBytesCalculado.Replace("bytes", ""));
                }

            }
            catch(ApplicationException ex)
            {

                await _geradorDeLog.GerarLog($"Erro: {ex.Message}");


                await _geradorDeLog.GerarLog($"Executando estratégia de fallback.");


                return _contadorDeBytesWebFallback.ContarBytesDoTexto(texto);

            }
        }
    }
}
