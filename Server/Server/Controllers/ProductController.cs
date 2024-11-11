using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Functions.Command;
using Server.Models.Functions.Query;
using Server.Models;
using Server.Validators;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductOrderOptions options)
        {
            var request = new GetAllProductsQuery
            {
                OrderOptions = options
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductRequest request)
        {
            var validator = new ProductRequestValidator();
            var validationResult = validator.Validate(request);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.FirstOrDefault());
            }

            var command = new InsertProductCommand
            {
                Code = request.Code,
                Name = request.Name,
                Price = request.Price
            };
            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.Errors.FirstOrDefault()!.Message);
        }
    }
}
