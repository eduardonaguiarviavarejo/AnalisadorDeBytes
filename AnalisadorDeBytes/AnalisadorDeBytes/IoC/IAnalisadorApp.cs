using AnalisadorDeBytes.App;
using AnalisadorDeBytes.App.Dto;
using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IAnalisadorApp
    {
        Task<AnaliseDto> AnalisarAsync(ParametrosDeAnaliseDto parametrosDeAnaliseDto);
    }
}
