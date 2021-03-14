using AnalisadorDeBytes.App;
using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using Xunit;

namespace AnalisadorDeBytes.Testes.App
{
    public class AnaliseAppTeste
    {
        private readonly int _tamanhoDoBufferBytes = 100000000;
        private readonly string _caminhoArquivo = @"c:\";
        private readonly IAnalisadorApp _analisadorApp;
        

        public AnaliseAppTeste()
        {
            _analisadorApp = new AnalisadorApp();
        }


        public async System.Threading.Tasks.Task AnalisarAsync_DeveGerarInformacoesDeAnaliseAsync()
        {
            await _analisadorApp.AnalisarAsync(new ParametrosDeAnaliseDto(_caminhoArquivo, _tamanhoDoBufferBytes, TiposDeRelatorio.Json));


            //Verificar geracao arquivo
        }
    }
}
