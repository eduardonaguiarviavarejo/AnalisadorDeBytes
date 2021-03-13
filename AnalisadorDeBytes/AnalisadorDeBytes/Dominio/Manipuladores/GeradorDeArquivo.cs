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
        public async Task<GeradorDeArquivoResposta> ExecutarAsync(GeradorDeArquivoComando comando)
        {
            Stopwatch diagnostico = new Stopwatch();
            diagnostico.Start();


            
            var buffer = new byte[comando.TamanhoDoBuffer];




            var tamanhoDoTexto = RetornarTamanhoEmBytesDaString(comando.TextoAnalisado);

            string textoIncremental = null;

            var numeroDeIteracoes = 0;

            while (tamanhoDoTexto <= comando.TamanhoDoBuffer)
            {
                textoIncremental += comando.TextoAnalisado;

                tamanhoDoTexto = RetornarTamanhoEmBytesDaString(textoIncremental);

                numeroDeIteracoes++;
            }


            buffer = ASCIIEncoding.Unicode.GetBytes(textoIncremental);




            var nomeDoArquivo = await EscreverArquivo(comando.CaminhoDoArquivo, buffer);


            diagnostico.Stop();



            return new GeradorDeArquivoResposta(nomeDoArquivo, buffer.Length, comando.CaminhoDoArquivo, new Metricas(numeroDeIteracoes, diagnostico.Elapsed, diagnostico.Elapsed / numeroDeIteracoes));
        }




        private int RetornarTamanhoEmBytesDaString(string texto)
        {
            return ASCIIEncoding.Unicode.GetByteCount(texto);
        }




        private async Task<string> EscreverArquivo(string caminhoDoArquivo, byte[] buffer)
        {

            string nomeDoArquivo = $"{DateTime.Now.ToString("YYYY-MM-DD-HHmmss")}-arquivo-gerado.txt";

            using (var fs = new FileStream(nomeDoArquivo, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(buffer, 0, buffer.Length);
            }

            return nomeDoArquivo;
        }
    }
}
