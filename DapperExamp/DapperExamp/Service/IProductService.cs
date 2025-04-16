using DapperExamp.Dtos;

namespace DapperExamp.Service
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto product);
        Task UpdateProductAsync(UpdateProductDto product);
        Task DeleteProductAsync(int id);
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
    }
}
