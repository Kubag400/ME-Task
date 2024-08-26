using MediatR;

namespace Server.Models.Functions.Query
{
    public class GetAllProductsQuery: IRequest<List<ProductEntity>>
    {
        public ProductOrderOptions OrderOptions { get; init; }
    }
}
