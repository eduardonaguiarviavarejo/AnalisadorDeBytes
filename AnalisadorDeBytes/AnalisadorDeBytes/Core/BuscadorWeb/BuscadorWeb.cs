using Abot2.Crawler;
using Abot2.Poco;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.BuscadorWeb
{
    public class BuscadorWeb : IBuscadorWeb
    {
        private readonly BuscadorWebConfig _buscadorWebConfig;



        public BuscadorWeb(BuscadorWebConfig buscadorWebConfig)
        {
            _buscadorWebConfig = buscadorWebConfig;
        }



        public async Task<string> Buscar(Uri urlDoSiteASerBuscado)
        {
            var config = new CrawlConfiguration
            {
                CrawlTimeoutSeconds = 100,
                MaxConcurrentThreads = 10,
                MaxPagesToCrawl = 1000,
                MinCrawlDelayPerDomainMilliSeconds = 3000
            };

                        
            
            var crawler = new PoliteWebCrawler(config);


            
            string todoOTtextoASerRetornado = null;



            crawler.PageCrawlCompleted += (object sender, PageCrawlCompletedArgs e) =>
            {
                var texto = e.CrawledPage.AngleSharpHtmlDocument.All.Where(x => x.LocalName == _buscadorWebConfig.SeletorDeBuscaTextual);

                foreach (var item in texto)
                {
                    todoOTtextoASerRetornado += item.TextContent;
                }
            };



            
            await crawler.CrawlAsync(urlDoSiteASerBuscado);



            return todoOTtextoASerRetornado;
        }
    }
}
