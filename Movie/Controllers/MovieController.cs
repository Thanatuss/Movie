using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("Get")]
        public IActionResult GetMovies()
        {
            return Ok();
        }
        [HttpPost("Add")]
        public IActionResult AddMovie()
        {
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult UpdateMovie()
        {
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteMovie()
        {
            return Ok();
        }
    }
}
