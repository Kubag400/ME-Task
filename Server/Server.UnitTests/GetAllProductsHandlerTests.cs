using FluentResults;
using Moq;
using Server.Models;
using Server.Models.Functions.Query;
using Server.Services;

namespace Server.UnitTest
{
    public class GetAllProductsHandlerTests
    {
        private readonly GetAllProductsHandler _handler;
        private Mock<IProductService> _productService;
        public GetAllProductsHandlerTests()
        {
            _productService = new Mock<IProductService>();
            _handler = new GetAllProductsHandler(_productService.Object);
        }
        [Fact]
        public async void DefaultSettingsForGetAllProducts_ReturnsListUnchanged()
        {

            _productService.Setup(x => x.GetProductsAsync()).ReturnsAsync(FixPositiveResult());
            var request = new GetAllProductsQuery
            {
                OrderOptions = ProductOrderOptions.None
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Code1", result[0].Code);
            Assert.Equal("Code2", result[1].Code);
            Assert.Equal("Code3", result[2].Code);
        }

        [Fact]
        public async void DescendingSettingsForGetAllProducts_ReturnsListInCorrectOrder()
        {

            _productService.Setup(x => x.GetProductsAsync()).ReturnsAsync(FixPositiveResult());
            var request = new GetAllProductsQuery
            {
                OrderOptions = ProductOrderOptions.ByPriceDesc
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Code1", result[0].Code);
            Assert.Equal("Code3", result[1].Code);
            Assert.Equal("Code2", result[2].Code);
        }


        [Fact]
        public async void AscendingSettingsForGetAllProducts_ReturnsListInCorrectOrder()
        {

            _productService.Setup(x => x.GetProductsAsync()).ReturnsAsync(FixPositiveResult());
            var request = new GetAllProductsQuery
            {
                OrderOptions = ProductOrderOptions.ByPriceAsc
            };
            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Code2", result[0].Code);
            Assert.Equal("Code3", result[1].Code);
            Assert.Equal("Code1", result[2].Code);
        }


        private Result<List<ProductEntity>> FixPositiveResult()
        {
            var list = new List<ProductEntity>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Code = "Code1",
                    Name = "HighestPriceItem",
                    Price = 5000
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Code = "Code2",
                    Name = "MidItem",
                    Price = 20,
                },
                                new()
                {
                    Id = Guid.NewGuid(),
                    Code = "Code3",
                    Name = "LastItem",
                    Price = 95,
                }
            };
            return Result.Ok(list);
        }
    }
}