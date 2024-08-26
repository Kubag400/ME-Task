using Server.Services;

namespace Server.Models.Functions.Query
{
    public class GetAllProductsHandler
    {
        private readonly IProductService _productService;

        public GetAllProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _productService.GetProductsAsync();
            return request.OrderOptions switch
            {
                ProductOrderOptions.None => data.Value,
                ProductOrderOptions.ByPriceDesc => data.Value.OrderByDescending(x => x.Price).ToList(),
                ProductOrderOptions.ByPriceAsc => data.Value.OrderBy(x => x.Price).ToList(),
                _ => new List<ProductEntity>()
            };
        }
    }
}
