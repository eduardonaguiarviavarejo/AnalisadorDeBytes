using AnalisadorDeBytes.Core.Componentes.Log;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.Componentes.GeradorDeLog
{
    public class GeradorDeLog : IGeradorDeLog
    {
        public Task GerarLogAsync(string mensagem)
        {
            return Task.Run(() => Console.WriteLine(mensagem));
        }
    }
}
