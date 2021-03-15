using AnalisadorDeBytes.App;
using AnalisadorDeBytes.Dominio.Modelo;
using CommandLine;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes
{
    class Program
    {
        public class Options
        {
            [Option('f', "formato", Required = false, HelpText = "Formato do relatorio")]
            public TiposDeRelatorio TipoRelatorio { get; set; }

            [Option('c', "caminho", Required = false, HelpText = @"Caminho de gravaçao do arquivo. Ex.: c:\.")]
            public string Caminho { get; set; }

            [Option('b', "buffer", Required = false, HelpText = "Tamanho do buffer em bytes.")]
            public int TamanhoBuffer { get; set; }

        }

        static async Task Main(string[] args)
        {
            await Parser.Default
                .ParseArguments<Options>(args)
               .WithParsedAsync<Options>(RunOptionsAsync);
        }

        static async Task RunOptionsAsync(Options opts)
        {
            await new AnalisadorApp().AnalisarAsync(new ParametrosDeAnaliseDto(opts.Caminho, opts.TamanhoBuffer, opts.TipoRelatorio));
        }
    }
}
