using AnalisadorDeBytes.App;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new AnalisadorApp().AnalisarAsync(new ParametrosDeAnaliseDto("c:/dev", 1000000));


            Console.ReadKey();
        }
    }
}
