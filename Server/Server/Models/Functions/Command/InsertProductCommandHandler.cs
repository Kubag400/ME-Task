using FluentResults;
using MediatR;
using Server.Services;

namespace Server.Models.Functions.Command
{
    public class InsertProductCommandHandler : IRequestHandler<InsertProductCommand, Result>
    {
        private readonly IProductService _productService;
        public InsertProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductEntity
            {
                Code = request.Code,
                Name = request.Name,
                Price = request.Price,
                Id = Guid.NewGuid()
            };

            return await _productService.InsertProductAsync(entity);
        }
    }
}
