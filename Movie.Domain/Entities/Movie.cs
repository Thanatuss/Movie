using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int DurationMinutes { get; private set; }

        public string Director { get; private set; }
        public List<string> Cast { get; private set; } = new();

        public List<Genre> Genres { get; private set; } = new();
        public string Language { get; private set; }
        public string Country { get; private set; }

        public string AgeRating { get; private set; }

        public string StreamUrl { get; private set; }
        public string ThumbnailUrl { get; private set; }

        public bool IsPublished { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        private Movie() { }
        public Movie(string title, string description, DateTime releaseDate, int durationMinutes,
                     string director, List<string> cast, List<Genre> genres, string language,
                     string country, string ageRating, string streamUrl, string thumbnailUrl)
        {
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            DurationMinutes = durationMinutes;
            Director = director;
            Cast = cast;
            Genres = genres;
            Language = language;
            Country = country;
            AgeRating = ageRating;
            StreamUrl = streamUrl;
            ThumbnailUrl = thumbnailUrl;
            IsPublished = false; // Default value
        }
        // Constructor
        /*public Movie(
            string title,
            string description,
            DateTime releaseDate,
            int durationMinutes,
            string director,
            List<string> cast,
            List<Genre> genres,
            string language,
            string country,
            string ageRating,
            string streamUrl,
            string thumbnailUrl)
        {
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            DurationMinutes = durationMinutes;
            Director = director;
            Cast = cast;
            Genres = genres;
            Language = language;
            Country = country;
            AgeRating = ageRating;
            StreamUrl = streamUrl;
            ThumbnailUrl = thumbnailUrl;
            IsPublished = false;
        }
        */
        //public void Publish() => IsPublished = true;
        //public void UpdateInfo(...) { /* Update logic */ }
    }
}
