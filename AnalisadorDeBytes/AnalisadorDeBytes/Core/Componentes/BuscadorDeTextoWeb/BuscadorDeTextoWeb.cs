using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public class BuscadorDeTextoWeb : IBuscadorDeTextoWeb
    {
        
        private Browser _browse;



        public BuscadorDeTextoWeb()
        {
            new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

        }


        public async Task<string> Buscar(Uri urlDoSiteASerBuscado)
        {
            using (var page = await _browse.NewPageAsync())
            {

                await page.GoToAsync(urlDoSiteASerBuscado.AbsoluteUri);



                string textoExtraido = await page.QuerySelectorAsync(".sentence").EvaluateFunctionAsync<string>("_ => _.innerText");



                return textoExtraido;
            }
        }
    }
}
