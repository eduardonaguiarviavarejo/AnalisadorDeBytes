using System.Threading.Tasks;

namespace AnalisadorDeBytes.IoC
{
    public interface IMap<TDto, TModel>
        where TDto : IDto
        where TModel : IModel
    {
        Task<TDto> ModelToDtoAsync(TModel model);
        Task<TModel> DtoToModelAsync(TDto dto);
    }
}
