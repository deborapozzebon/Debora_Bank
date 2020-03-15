using Microsoft.AspNetCore.Mvc;

namespace Debora_Bank.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetHome()
        {
            return Ok();
        }
    }
}
