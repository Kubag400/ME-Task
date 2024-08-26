using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpGet("/Index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
