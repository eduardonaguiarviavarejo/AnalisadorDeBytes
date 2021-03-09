using AnalisadorDeBytes.Dominio;
using System;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IAnalisador
    {
        Task<InformacoesDaAnalise> ProcessarAsync(Uri paginaWebParaBuscaDosTextos, string caminhoDoArquivo, int tamanhoDoBuffer = 1);
    }
}
