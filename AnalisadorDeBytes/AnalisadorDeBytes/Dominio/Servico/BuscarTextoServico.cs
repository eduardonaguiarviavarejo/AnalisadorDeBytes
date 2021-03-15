using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Core.Componentes.Log;
using AnalisadorDeBytes.Infra.Crawler;
using AnalisadorDeBytes.IoC;
using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Servico
{
    public class BuscarTextoServico : IBuscadorDeTextoWeb
    {

        private const string SITEWEB = "http://lerolero.com";
        private readonly IBuscadorDeTextoWebFallback _buscadorDeTextoWebFallback;
        private readonly IGeradorDeLog _geradorDeLog;

        public BuscarTextoServico(
            IBuscadorDeTextoWebFallback buscadorDeTextoWebFallback,
            IGeradorDeLog geradorDeLog)
        {
            _buscadorDeTextoWebFallback = buscadorDeTextoWebFallback;
            _geradorDeLog = geradorDeLog;
        }

        public async Task<string> Buscar()
        {

            Browser _browse;

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            _browse = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });


            using (var page = await _browse.NewPageAsync())
            {
                try
                {
                    await page.GoToAsync(SITEWEB);

                    await _geradorDeLog.GerarLogAsync($"Iniciando crawler para buscar texto.");

                    string textoExtraido = await page.QuerySelectorAsync(".sentence").EvaluateFunctionAsync<string>("_ => _.innerText");

                    return textoExtraido;
                }
                catch (Exception ex)
                {
                    await _geradorDeLog.GerarLogAsync($"Erro: {ex.Message}");

                    await _geradorDeLog.GerarLogAsync($"Executando estratégia de fallback.");

                    return await _buscadorDeTextoWebFallback.BuscarTextoAleatorio();
                }
            }
        }
    }
}