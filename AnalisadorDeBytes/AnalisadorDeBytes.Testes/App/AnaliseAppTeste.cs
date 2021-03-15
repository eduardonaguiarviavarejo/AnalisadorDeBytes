using AnalisadorDeBytes.App;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AnalisadorDeBytes.Testes.App
{
    public class AnaliseAppTeste : IDisposable
    {
        private readonly int _tamanhoDoBufferBytes = 1000000;
        private readonly string _caminhoArquivo = @"c:\dev";
        private readonly IAnalisadorApp _analisadorApp;
        private string arquivo = null;
        

        public AnaliseAppTeste()
        {
            _analisadorApp = new AnalisadorApp();
        }


        [Fact]
        public async Task AnalisarAsync_DeveGerarInformacoesDeAnaliseAsync()
        {
            var retorno = await _analisadorApp.AnalisarAsync(new ParametrosDeAnaliseDto(_caminhoArquivo, _tamanhoDoBufferBytes, TiposDeRelatorio.Json));

            arquivo = Path.Combine(retorno.CaminhoFisico, retorno.NomeDoArquivo);
                                    
            Assert.True(File.Exists(arquivo));
        }

        public void Dispose()
        {
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }
        }
    }
}
