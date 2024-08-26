using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Functions.Command;
using Server.Models.Functions.Query;
using Server.Models;

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

        [HttpGet("/GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts([FromQuery] ProductOrderOptions options)
        {
            var request = new GetAllProductsQuery
            {
                OrderOptions = options
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("/InsertProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertProduct([FromBody] ProductRequest request)
        {
            var command = new InsertProductCommand
            {
                Code = request.Code,
                Name = request.Name,
                Price = request.Price
            };
            var result = await _mediator.Send(command);

            return BadRequest();
        }
    }
}
