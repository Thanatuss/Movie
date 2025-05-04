using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Application.DTOs.Movie;
using Movie.Domain.Entities;

namespace Movie.Application.Exceptions
{
    public class MovieValidation
    {
        public static string? AddValidate(AddMovieDto movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
                return "Title cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.Description))
                return "Description cannot be empty.";
            if (movie.DurationMinutes <= 0)
                return "Duration must be greater than zero.";
            if (string.IsNullOrWhiteSpace(movie.Director))
                return "Director cannot be empty.";
            if (movie.Cast == null || !movie.Cast.Any())
                return "Cast must have at least one member.";
            if (movie.Genres == null || !movie.Genres.Any())
                return "Genres must have at least one entry.";
            if (string.IsNullOrWhiteSpace(movie.Language))
                return "Language cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.Country))
                return "Country cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.StreamUrl))
                return "StreamUrl cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.ThumbnailUrl))
                return "ThumbnailUrl cannot be empty.";

            return null; // No validation errors
        }
        public static string? UpdateValidate(UpdateMovieDto movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Title))
                return "Title cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.Description))
                return "Description cannot be empty.";
            if (movie.DurationMinutes <= 0)
                return "Duration must be greater than zero.";
            if (string.IsNullOrWhiteSpace(movie.Director))
                return "Director cannot be empty.";
            if (movie.Cast == null || !movie.Cast.Any())
                return "Cast must have at least one member.";
            if (movie.Genres == null || !movie.Genres.Any())
                return "Genres must have at least one entry.";
            if (string.IsNullOrWhiteSpace(movie.Language))
                return "Language cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.Country))
                return "Country cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.StreamUrl))
                return "StreamUrl cannot be empty.";
            if (string.IsNullOrWhiteSpace(movie.ThumbnailUrl))
                return "ThumbnailUrl cannot be empty.";

            return null; // No validation errors
        }



    }
}
