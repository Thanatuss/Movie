using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserProfile UserProfile { get; set; }
    }
    public enum UserRole
    {
        User , 
        Admin
    }
}
