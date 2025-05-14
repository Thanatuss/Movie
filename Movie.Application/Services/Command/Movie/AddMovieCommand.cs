using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.DTOs.Movie;
using Movie.Application.Exceptions;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command.Movie
{
    public class AddMovieCommand : IRequest<ResultExceptionService>
    {
        public AddMovieDto AddMovieDto { get; set; }
        public AddMovieCommand(AddMovieDto getMovieDto)
        {
            AddMovieDto = getMovieDto;
        }
    }
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbContext;
        private readonly ILogger<AddMovieHandler>  _logger;
        public AddMovieHandler(ProgramDbContext dbContext, ILogger<AddMovieHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<ResultExceptionService> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var validation = MovieValidation.AddValidate(request.AddMovieDto);
            if(validation != null)
                return await ResultExceptionService
                    .Error($"{validation}");
            try
            {
                var info = request.AddMovieDto;
                var newMovie = new Domain.Entities.Movie(
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
                await _dbContext.Movies.AddAsync(newMovie , cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("AddMovieHandler is closed successfully!");
                return await ResultExceptionService
                    .Success("Add is successfull!");

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while adding a movie!");

                return await ResultExceptionService.Error(ex.Message);

            }

        }
    }
}
