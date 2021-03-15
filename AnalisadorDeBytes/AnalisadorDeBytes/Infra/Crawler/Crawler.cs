using PuppeteerSharp;

namespace AnalisadorDeBytes.Infra.Crawler
{
    public class Crawler 
    {

        private Crawler() {}

        private static Browser _instance;

        public static Browser GetInstanceAsync()
        {

            if (_instance == null)
            {                

                new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

                _instance = Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true

                }).Result;
            }
            
            return _instance;
        }
    }
}
