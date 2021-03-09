using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class GeradorDeArquivo : IGeradorDeArquivo
    {
        public Task<GeradorDeArquivoResposta> ExecutarAsync(GeradorDeArquivoComando comando)
        {
            throw new NotImplementedException();
        }
    }
}
