using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductEntity>().HasKey(p => p.Id);
            builder.Entity<ProductEntity>().HasData(
                new ProductEntity { Id = Guid.NewGuid(), Code = "P1", Name = "JBL", Price = 100 },
                new ProductEntity { Id = Guid.NewGuid(), Code = "P1", Name = "TV", Price = 5000 },
                new ProductEntity { Id = Guid.NewGuid(), Code = "P1", Name = "HeadPhones", Price = 30 });
            base.OnModelCreating(builder);
        }
    }
}
