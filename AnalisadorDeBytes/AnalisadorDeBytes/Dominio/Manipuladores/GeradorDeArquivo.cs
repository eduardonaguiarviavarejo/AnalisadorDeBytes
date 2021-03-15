using AnalisadorDeBytes.Dominio.Comandos;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.Dominio.Respostas;
using AnalisadorDeBytes.IoC;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.Dominio.Manipuladores
{
    public class GeradorDeArquivo : IGeradorDeArquivo
    {
        private const int TAMANHODOBUFFEREMBYTESDEFAULT = 1000000;

        public async Task<GeradorDeArquivoResposta> ExecutarAsync(GeradorDeArquivoComando comando)
        {
            Stopwatch diagnostico = new Stopwatch();

            diagnostico.Start();

            var tamanhoBufferValidado = comando.TamanhoDoBufferEmBytes ?? TAMANHODOBUFFEREMBYTESDEFAULT;

            var buffer = new byte[tamanhoBufferValidado * 1024];

            var tamanhoDoTexto = RetornarTamanhoEmBytesDaString(comando.TextoAnalisado);

            string textoIncremental = null;

            var numeroDeIteracoes = 0;



            do
            {
                textoIncremental += comando.TextoAnalisado;

                tamanhoDoTexto = RetornarTamanhoEmBytesDaString(textoIncremental);

                numeroDeIteracoes++;
            } while (tamanhoDoTexto < tamanhoBufferValidado);


            buffer = ASCIIEncoding.Unicode.GetBytes(textoIncremental);

            var nomeDoArquivo = await EscreverArquivo(comando.CaminhoDoArquivo, buffer);

            diagnostico.Stop();

            return new GeradorDeArquivoResposta(nomeDoArquivo, buffer.Length, comando.CaminhoDoArquivo, numeroDeIteracoes);
        }

        private int RetornarTamanhoEmBytesDaString(string texto)
        {
            return ASCIIEncoding.Unicode.GetByteCount(texto);
        }

        private async Task<string> EscreverArquivo(string caminhoDoArquivo, byte[] buffer)
        {
            string nomeDoArquivo = $"{DateTime.Now.ToString("yyyy-MM-dd-HHmmss")}-arquivo-gerado.txt";

            using (var fs = new FileStream($@"{ caminhoDoArquivo }\{ nomeDoArquivo }", FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(buffer, 0, buffer.Length);
            }

            return nomeDoArquivo;
        }
    }
}