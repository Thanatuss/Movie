using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces.JWT;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command.Authentication
{
    public class LoginCommand : IRequest<ResultExceptionService>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginHandler : IRequestHandler<LoginCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbcontext;
        private readonly ITokenService _token;

        public LoginHandler(ProgramDbContext dbcontext, ITokenService token)
        {
            _dbcontext = dbcontext;
            _token = token;
        }

        public async Task<ResultExceptionService> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var username = request.Username;
            var password = request.Password;
            try
            {
                var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Fullname == username && x.Password == password && x.IsDeleted == false);
                if (user != null)
                {
                    var token = _token.CreateToken(user);
                    return await ResultExceptionService.Success($"Login successful - Your token is {token}");
                }
                return await ResultExceptionService.Error($"Login failds");
            }
            catch (Exception ex)
            {
                return await ResultExceptionService.Error("An unexpected error occurred.");

            }
        }
    }
}
