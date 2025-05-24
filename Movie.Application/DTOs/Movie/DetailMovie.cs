using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Entities;

namespace Movie.Application.DTOs.Movie
{
    public class DetailMovie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DurationMinutes { get; set; }

        public string Director { get; set; }
        public List<string> Cast { get; set; } = new();

        public List<Genre> Genres { get; set; } = new();
        public string Language { get; set; }
        public string Country { get; set; }

        public string AgeRating { get; set; }

        public string StreamUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
