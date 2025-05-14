using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Application.DTOs.Movie;
using Movie.Application.Exceptions;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Persistence;

namespace Movie.Application.Services.Command
{
    public class DeleteMovieCommand : IRequest<ResultExceptionService>
    {
        public DeleteMovieDto DeleteMovieDto { get; set; }

        public DeleteMovieCommand(DeleteMovieDto deleteMovieDto)
        {
            DeleteMovieDto = deleteMovieDto;
        }
    }
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbcontext;
        private readonly ILogger<DeleteMovieHandler> _logger;
        public DeleteMovieHandler(ProgramDbContext dbcontext, ILogger<DeleteMovieHandler> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public async Task<ResultExceptionService> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var information = request.DeleteMovieDto;
            var validation = MovieValidation.DeleteValidate(information);
            try
            {
                var movie = await _dbcontext.Movies.FirstOrDefaultAsync(x => x.Title == information.Title || x.Id == information.Id);
                _dbcontext.Movies.Remove(movie);
                await _dbcontext.SaveChangesAsync();
                _logger.LogInformation("DeleteMovieHandler is closed successfully!");
                return await ResultExceptionService.Success("Done successfully!");

            }
            catch(Exception ex)
            {
                _logger.LogError($"DeleteMovieHandler is closed suddenly : {ex.Message}!");
                return await ResultExceptionService.Success($"Done with error : {ex.Message}!");
            }
        }
    }
}
