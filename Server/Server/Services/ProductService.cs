using FluentResults;
using Server.Models;

namespace Server.Services
{
    public class ProductService : IProductService
    {
        //TODO: Implement SQLite/InMemory implementation
        public async Task<Result<List<ProductEntity>>> GetProductsAsync()
        {
            var items = new List<ProductEntity>
            {
                new()
                {
                    Code = "1",
                    Id = Guid.NewGuid(),
                    Name = "N1",
                    Price = 110
                },
                new()
                {
                    Code = "2",
                    Id = Guid.NewGuid(),
                    Name = "N2",
                    Price = 5000,
                },
                new()
                {
                    Code = "3",
                    Id = Guid.NewGuid(),
                    Name = "N3",
                    Price = 50,
                },

            };
            return Result.Ok(items);
        }

        public Task<Result> InsertProductAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
