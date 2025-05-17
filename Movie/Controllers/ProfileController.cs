using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok();
        }
    }
}
