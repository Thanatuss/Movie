using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Movie.Application.DTOs.Authentication
{
    public class RegisterDto
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IFormFile? ProfileImage { get; set; } 


    }
}
