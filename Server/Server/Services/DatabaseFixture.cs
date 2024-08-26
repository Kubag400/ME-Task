
using Server.Models;

namespace Server.Services
{
    public sealed class DatabaseFixture : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseFixture> _logger;

        public DatabaseFixture(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

            try
            {
                db.Database.EnsureCreated();
                var startItems = new List<ProductEntity>()
                {
                    new()
                    {
                        Code = "XZ1",
                        Id = Guid.NewGuid(),
                        Name = "First Random Item",
                        Price = 200,
                    },
                    new()
                    {
                        Code = "XY2",
                        Id = Guid.NewGuid(),
                        Name = "Second Paper Element",
                        Price = 5000,
                    },
                    new()
                    {
                        Code = "XU3",
                        Id = Guid.NewGuid(),
                        Name = "Third Item",
                        Price = 50,
                    },
                };
                await db.Products.AddRangeAsync(startItems);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
