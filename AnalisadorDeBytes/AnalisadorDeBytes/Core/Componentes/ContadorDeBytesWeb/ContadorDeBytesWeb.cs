using PuppeteerSharp;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.Componentes.ContadorDeBytesWeb
{
    public class ContadorDeBytesWeb : IContadorDeBytesWeb
    {
        private Browser _browser;

        public ContadorDeBytesWeb()
        {
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }


        public async Task<int> ContarBytesPorTextoAsync(string texto)
        {
            using (var paginaBuscada = await _browser.NewPageAsync())
            {
                await paginaBuscada.GoToAsync($"https://mothereff.in/byte-counter#{texto}");

                
                
                string valorEmBytesCalculado = await paginaBuscada.EvaluateExpressionAsync<string>("document.getElementById('bytes').textContent");

                
                
                return int.Parse(valorEmBytesCalculado.Replace("bytes", ""));
            }
        }
    }
}
