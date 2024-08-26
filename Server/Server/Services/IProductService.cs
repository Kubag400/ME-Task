using FluentResults;
using Server.Models;

namespace Server.Services
{
    public interface IProductService
    {
        Task<Result<List<ProductEntity>>> GetProductsAsync();
        Task<Result> InsertProductAsync(ProductEntity entity);
    }
}
