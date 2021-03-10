using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class ContadorDeBytes : IContadorDeBytes
    {
        private static readonly HttpClient client = new HttpClient();        


        public async Task<ContadorDeBytesResposta> ExecutarAsync(ContadorDeBytesComando comando)
        {
            
            HttpResponseMessage response = await client.GetAsync("https://mothereff.in/byte-counter#uasdASDasdsdfsdfasdfasdfasdfasdfasdfasdfaqwsasdasdasdasdasd");


            string responseBody = null;


            responseBody = await response.Content.ReadAsStringAsync();
            

            return new ContadorDeBytesResposta(213213);
        }
    }
}
