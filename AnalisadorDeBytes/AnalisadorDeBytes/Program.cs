using AnalisadorDeBytes.Core.BuscadorWeb;
using AnalisadorDeBytes.Dominio.Manipuladores;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new ContadorDeBytes().ExecutarAsync(new Dominio.Comandos.ContadorDeBytesComando("sdfasjdfljasldjkf"));

            Console.ReadKey();
        }
    }
}
