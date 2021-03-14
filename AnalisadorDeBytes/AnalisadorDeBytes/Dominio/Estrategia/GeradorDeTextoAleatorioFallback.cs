using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.IoC;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Estrategia
{
    public class GeradorDeTextoAleatorioFallback : IBuscadorDeTextoWebFallback
    {
        public Task<string> BuscarTextoAleatorio()
        {
            return Task.Run(() =>
            {
                               
                var rand = new Random();

               
                var textoAleatorio = AnalisadorDeBytes.Properties.Resources.ResourceManager.GetString(rand.Next(1, 5).ToString());


                //ResourceSet resourceSet = AnalisadorDeBytes.Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                

                return textoAleatorio;

            });
        }
    }
}
