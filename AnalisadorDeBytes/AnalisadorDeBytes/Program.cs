using AnalisadorDeBytes.App;
using AnalisadorDeBytes.Dominio.Modelo;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new AnalisadorApp().AnalisarAsync(new ParametrosDeAnaliseDto(TiposDeRelatorio.Tabela, "c:/dev", 10000));


            Console.ReadKey();
        }
    }
}
