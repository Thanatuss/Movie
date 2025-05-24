using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.DTOs.Movie;
using Movie.Application.Services.Command;
using Movie.Application.Services.Command.Movie;
using Movie.Application.Services.Query;
using Movie.Application.Services.Query.Movie;

namespace Movie.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MovieController> _logger;
        public MovieController(IMediator mediator, ILogger<MovieController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("Get")]
        [AllowAnonymous]
        public IActionResult GetMovies()
        {
            _logger.LogInformation("Start GetMovies action");
            var command = new GetMovieCommand();
            var result = _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("Detail/{Id}")]
        [AllowAnonymous]
        public IActionResult DetailMovie(string Id)
        {
            var command = new GetDetailMovieCommand(Id);
           // add this movie into watched histoy
            _logger.LogInformation("Start GetMovies action");
            var result = _mediator.Send(command);
            var test = "Test";
            return Ok(result.Result != null ? result.Result : "null");
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
        [AllowAnonymous]
        public async Task<IActionResult> DeleteMovie(DeleteMovieDto deleteMovieDto)
        {
            var command = new DeleteMovieCommand(deleteMovieDto);
            var result =await _mediator.Send(command);
            return Ok(result);
        }
    }
}
