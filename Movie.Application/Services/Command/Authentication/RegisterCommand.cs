using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.Application.DTOs.Authentication;
using Movie.Application.Interfaces.JWT;
using Movie.Domain.Entities;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command.Authentication
{
    public class RegisterCommand : IRequest<ResultExceptionService>
    {
        public RegisterDto RegisterDto { get; set; }
        public RegisterCommand(RegisterDto register)
        {
            RegisterDto = register;
        }
    }
    public class RegisterHandler : IRequestHandler<RegisterCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbcontext;
        private readonly ITokenService _token;

        public RegisterHandler(ProgramDbContext dbcontext, ITokenService token)
        {
            _dbcontext = dbcontext;
            _token = token;
        }

        public async Task<ResultExceptionService> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = request.RegisterDto;
            var anyExist = await _dbcontext.Users.AnyAsync(x => x.Fullname == user.Username && x.Password == user.Password);
            if (!anyExist)
            {
                var newUser = new User
                {
                    Fullname = user.Username,
                    Password = user.Password,
                    Username = user.Username

                };
                await _dbcontext.Users.AddAsync(newUser);
                _dbcontext.SaveChanges();
                var token = _token.CreateToken(newUser);
                return await ResultExceptionService.Success($"You Registered successfully - Your token is {token}");
            }

            return await ResultExceptionService.Success("You could not register");
        }
    }
}
