using AnalisadorDeBytes.IoC;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Servico.Estrategia
{
    public class GeradorDeTextoAleatorioFallback : IBuscadorDeTextoWebFallback
    {
        //REFATORAR
        public Task<string> BuscarTextoAleatorio()
        {
            return Task.Run(() =>
            {                               
                var rand = new Random();

                
                var textoAleatorio = Properties.Resources.ResourceManager.GetString(rand.Next(1, 5).ToString());
                
                
                return textoAleatorio;
            });
        }
    }
}
