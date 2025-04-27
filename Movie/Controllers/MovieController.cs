using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Services.Query;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get")]
        public IActionResult GetMovies()
        {
            var command = new GetMovieCommand();
            var result = _mediator.Send(command);
            return Ok(result);
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
