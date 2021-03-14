using AnalisadorDeBytes.App;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IAnalisadorApp
    {
        Task AnalisarAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto);
    }
}
