using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.DTOs.Authentication
{
    public class RegisterDto
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
