using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
