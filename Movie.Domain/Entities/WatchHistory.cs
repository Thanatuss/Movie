using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Movie.Domain.Entities
{
    public class WatchHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime LastWatchedAt { get; set; }
    }
}
