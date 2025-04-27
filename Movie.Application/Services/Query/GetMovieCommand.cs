using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Abstractions;
using Movie.Application.DTOs.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Exceptions;
using Movie.Infrastructure.Elastic;
using Movie.Infrastructure.Model;
using Movie.Infrastructure.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Movie.Application.Services.Query
{
    public class GetMovieCommand : IRequest<ResultExceptionService>
    {
        public string RequestNumber { get; set; }
    }
    public class GetMovieHandler : IRequestHandler<GetMovieCommand, ResultExceptionService>
    {
        private readonly ProgramDbContext _dbContext;
        private readonly ElasticLogger _logger;
        public GetMovieHandler(ProgramDbContext dbContext, ElasticLogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Task<ResultExceptionService> Handle(GetMovieCommand request, CancellationToken cancellationToken)
        
        {

            try
            {
                var data = _dbContext.Movies.Where(x => x.IsDeleted == false).ToList();
                return ResultExceptionService.Success(JsonSerializer.Serialize(data));

            }
            catch
            {
                return ResultExceptionService.Success(Convert.ToString("An Error has accured!"));
            }
            
        }
    }
}
