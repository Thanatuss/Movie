using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Query.Profile
{
    public class GetProfileCommand : IRequest<List<object>>
    {
    }
    public class GetProfileHandler : IRequestHandler<GetProfileCommand, List<object>>
    {
        private readonly ProgramDbContext _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<GetProfileHandler> _logger;
        public GetProfileHandler(ProgramDbContext dbcontext, IHttpContextAccessor httpContextAccessor, ILogger<GetProfileHandler> logger)
        {
            _dbcontext = dbcontext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<List<object>> Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;
            if (String.IsNullOrEmpty(userId))
            {
                return new List<object>();
            }
            try
            {
                var result = await _dbcontext.Users
                .Where(user => user.Id == Guid.Parse(userId))
                .Join(_dbcontext.UserProfile,
                      user => user.Id,
                      profile => profile.UserId,
                      (user, profile) => new
                      {
                          Fullname = user.Fullname,
                          UserId = user.Id,
                          Username = user.Username,
                          Address = profile.Address,
                          PhoneNumber = profile.PhoneNumber,
                          DateOfBirth = profile.DateOfBirth,
                          Picture = profile.ProfilePictureUrl
                      })
                .ToListAsync(cancellationToken);
                _logger.LogInformation("Log {SERVICENAME} - lOGGING SUCCESSFULLY", nameof(GetProfileHandler));
                return result.Cast<object>().ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("Log {SERVICENAME} - lOGGING HAS ACCOURED", nameof(GetProfileHandler));
                return new List<object>();

            }

        }
    }
}
