using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Entities;

namespace Movie.Domain.Exceptions
{
    public class ResultExceptionService
    {
        public string Message { get; set; }
        public Status StatusCode { get; set; }
        public static async Task<ResultExceptionService>  Success(string message)
        {
            return new ResultExceptionService
            {
                Message = message,
                StatusCode = Status.Success
            };
        }
        public static async Task<ResultExceptionService> NotFound(string message)
        {
            return new ResultExceptionService
            {
                Message = message,
                StatusCode = Status.NotFound
            };
        }
        public static async Task<ResultExceptionService> Error(string message)
        {
            return new ResultExceptionService
            {
                Message = message,
                StatusCode = Status.Error
            };
        }
    }
    public enum Status
    {
        Success = 200,
        NotFound = 404,
        Error = 400
    }
}
