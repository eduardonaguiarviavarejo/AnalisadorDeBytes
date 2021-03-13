using AnalisadorDeBytes.Core.BuscadorWeb;
using System;
using System.Resources;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Estrategia
{
    public class GeradorDeTextoAleatorioFallback : IBuscadorDeTextoWebFallback
    {
        public Task<string> BuscarTextoAleatorio()
        {
            return Task.Run(() =>
            {
                ResourceManager recurso = new ResourceManager(@".\TextosAleatorios.resources", typeof(GeradorDeTextoAleatorioFallback).Assembly);


                var rand = new Random();


                return recurso.GetString(rand.Next(1, 5).ToString());
            });
        }
    }
}
