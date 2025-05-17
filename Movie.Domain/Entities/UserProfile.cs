using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public User User { get; set; }

    }
}
