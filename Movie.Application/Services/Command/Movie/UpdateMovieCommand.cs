using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Application.DTOs.Movie;
using Movie.Application.Exceptions;
using Movie.Domain.Entities;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command.Movie
{
    public class UpdateMovieCommand : IRequest<ResultExceptionService>
    {
        public UpdateMovieDto UpdateMovieDto { get; set; }
        public UpdateMovieCommand(UpdateMovieDto service)
        {
            UpdateMovieDto = service;
        }

    }
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, ResultExceptionService>
    {
        public ProgramDbContext _dbcontext { get; set; }
        private readonly ILogger<UpdateMovieHandler> _logger;
        public UpdateMovieHandler(ProgramDbContext dbcontext, ILogger<UpdateMovieHandler> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        public async Task<ResultExceptionService> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validation = MovieValidation.UpdateValidate(request.UpdateMovieDto);
            if (validation != null)
                return await ResultExceptionService.Error("Your information are not valid!");
            try
            {
                var info = request.UpdateMovieDto;
                var movie = await _dbcontext.Movies.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Title == info.Title);
                if (movie == null)
                    return await ResultExceptionService.NotFound("Movie not found");

                movie.UpdateInfo(
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
                await _dbcontext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("UpdateMovieHandler is closed successfully!");
                return await ResultExceptionService.Success("You changed the information successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while updating a movie!");
                return await ResultExceptionService.Success($"{ex.Message}");

            }
        }
    }
}
