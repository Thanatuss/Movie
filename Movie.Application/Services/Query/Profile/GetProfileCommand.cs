using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
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

        public GetProfileHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<object>> Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            return new List<object>();
            //var information = _dbcontext.Movies.Where();
            //var profile = _dbcontext.UserProfile.Where(x => x.Id == )
        }
    }
}
