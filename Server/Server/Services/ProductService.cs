using FluentResults;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _db;
        public ProductService(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<Result<List<ProductEntity>>> GetProductsAsync()
        {
            var items = await _db.Products.ToListAsync();
            return Result.Ok(items);
        }

        public async Task<Result> InsertProductAsync(ProductEntity entity)
        {
            await _db.Products.AddAsync(entity);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
                return Result.Ok();

            return Result.Fail("Insert product failed.");
        }
    }
}
