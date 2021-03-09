using AnalisadorDeBytes.Dominio;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IAnalisador
    {
        Task<InformacoesDaAnalise> ProcessarAsync(string caminhoDoArquivo, int tamanhoDoBuffer = 1);
    }
}
