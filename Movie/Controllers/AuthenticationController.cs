using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.DTOs.Authentication;
using Movie.Application.Services.Command.Authentication;

namespace Movie.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto register)
        {
            var command = new RegisterCommand(register);
            var result = _mediator.Send(command);
            return Ok(result.Result.Message);
        }
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginCommand login , CancellationToken cancel)
        {
            var command = login;
            var result = _mediator.Send(command , cancel);
            return Ok(result.Result.Message);
        }
    }
}
