using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
                var userId = await _dbcontext.Users.Where(x => x.Fullname == user.Username).Select(x => x.Id).FirstOrDefaultAsync();
                var filename = SaveFile(user.ProfileImage);
                var newProfile = new UserProfile()
                {
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = Convert.ToInt64(user.PhoneNumber),
                    ProfilePictureUrl = filename,
                    User = newUser,
                    UserId = userId

                };
                var addUserProfile = await _dbcontext.UserProfile.AddAsync(newProfile);
                await _dbcontext.SaveChangesAsync();
                var token = _token.CreateToken(newUser);
                return await ResultExceptionService.Success($"You Registered successfully - Your token is {token}");
            }
            return await ResultExceptionService.Success("You could not register");
        }
        public string SaveFile(IFormFile data)
        {
            var rootPath = Directory.GetCurrentDirectory();
            var uploadPath = Path.Combine(rootPath, "wwwroot", "uploads");
            Directory.CreateDirectory(uploadPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(data.FileName);
            var filePath = Path.Combine(uploadPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                data.CopyTo(stream);
            }
            return fileName;
        }
    }
}
