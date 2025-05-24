using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Services.Query.Profile;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator, ILogger<ProfileController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var command = new GetProfileCommand();
            var result = _mediator.Send(command);
            return Ok(result.Result);
        }
    }
}
