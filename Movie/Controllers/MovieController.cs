using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.DTOs.Movie;
using Movie.Application.Services.Command;
using Movie.Application.Services.Command.Movie;
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
        public IActionResult AddMovie(AddMovieDto AddMovieDto)
        {
            var command = new AddMovieCommand(AddMovieDto);
            var result = _mediator.Send(command);
            return Ok(result.Result.Message);
        }
        [HttpPut("Update")]
        public IActionResult UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            var command = new UpdateMovieCommand(updateMovieDto);
            var result = _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteMovie()
        {
            return Ok();
        }
    }
}
