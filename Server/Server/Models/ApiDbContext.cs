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
            base.OnModelCreating(builder);
        }
    }
}
