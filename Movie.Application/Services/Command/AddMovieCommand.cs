using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Movie.Application.DTOs.Movie;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command
{
    public class GetMovieCommand : IRequest<ResultExceptionService>
    {
        public GetMovieDto GetMovieDto { get; set; }
        public GetMovieCommand(GetMovieDto getMovieDto)
        {
            GetMovieDto = getMovieDto;
        }
    }
    public class GetMovieHandler : IRequestHandler<GetMovieCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbContext;
        public GetMovieHandler(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<ResultExceptionService> Handle(GetMovieCommand request, CancellationToken cancellationToken)
        {
            var info = request.GetMovieDto;
            var movie = new Domain.Entities.Movie(
                title: info.Title,
                description: info.Description,
                releaseDate: info.ReleaseDate,
                durationMinutes: info.DurationMinutes,
                director: info.Director,
                cast: info.Cast,
                genres: info.Genres,
                language: info.Language,
                country: info.Country,
                ageRating: info.AgeRating,
                streamUrl: info.StreamUrl,
                thumbnailUrl: info.ThumbnailUrl
                );
            var newMovie = _dbContext.Movies.AddAsync(movie);
            return ResultExceptionService
                .Success("Add is successfull!");

        }
    }
}
