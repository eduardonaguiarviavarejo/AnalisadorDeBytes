using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IManipulador<TComando, TResposta>
        where TComando : IComando
        where TResposta : IResposta
    {
        Task<TResposta> ExecutarAsync(TComando comando);
    }
}
