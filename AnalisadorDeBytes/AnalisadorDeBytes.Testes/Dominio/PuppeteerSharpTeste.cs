using PuppeteerSharp;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.Dominio
{
    public class PuppeteerSharpTeste
    {
        private static Page page;

        [Fact]
        public async Task DeveBuscarTextoOKAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("http://www.lerolero.com");                
                                
                string sentence = await page.QuerySelectorAsync(".sentence").EvaluateFunctionAsync<string>("_ => _.innerText");
            }
        }

        [Fact]
        public async Task DeveContarBytesOKAsync()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync("https://mothereff.in/byte-counter#dsgosdjfgjsdlfjgsdjfhopsdjfpokdsfkgsodfogosdfgosdofodgfogndofngodnof");

                string bytesString = await page.EvaluateExpressionAsync<string>("document.getElementById('bytes').textContent");

                var bytes = int.Parse(bytesString.Replace("bytes", ""));
            }
        }
    }
}
