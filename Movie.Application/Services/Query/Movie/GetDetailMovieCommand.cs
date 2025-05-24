using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movie.Application.DTOs.Movie;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Query.Movie
{
    public class GetDetailMovieCommand : IRequest<DetailMovie>
    {
        public string ID { get; set; }
        public GetDetailMovieCommand(string iD)
        {
            ID = iD;
        }
    }
    public class GetDetailMovieHandler : IRequestHandler<GetDetailMovieCommand , DetailMovie>
    {
        private readonly ProgramDbContext _dbcontext;

        public GetDetailMovieHandler(ProgramDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<DetailMovie> Handle(GetDetailMovieCommand request, CancellationToken cancellationToken)
        {
            var getdetail = _dbcontext.Movies.FirstOrDefault(x => x.Id == Guid.Parse(request.ID));
            if (!(getdetail is null))
                return new DetailMovie
                {
                    AgeRating = getdetail.AgeRating,
                    Cast = getdetail.Cast,
                    Country = getdetail.Country,
                    CreatedAt = getdetail.CreatedAt,
                    Description = getdetail.Description,
                    Director = getdetail.Director,
                    DurationMinutes = getdetail.DurationMinutes,
                    Genres = getdetail.Genres,
                    IsPublished = getdetail.IsPublished,
                    Language = getdetail.Language,
                    ReleaseDate = getdetail.ReleaseDate,
                    StreamUrl = getdetail.StreamUrl,
                    ThumbnailUrl = getdetail.ThumbnailUrl,
                    Title = getdetail.Title,
                    UpdatedAt = getdetail.UpdatedAt
                };
            return new DetailMovie
            {
                AgeRating = null,
                Cast = null,
                Country = null,
                CreatedAt = DateTime.Now,
                Description = null,
                Director = null,
                DurationMinutes = 0,
                Genres = null,
                IsPublished = false,
                Language = null,
                ReleaseDate = DateTime.Now,
                StreamUrl = null,
                ThumbnailUrl = null,
                Title = null,
                UpdatedAt = null
            };

        }
    }
}
