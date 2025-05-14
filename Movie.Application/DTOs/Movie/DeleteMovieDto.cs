using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.DTOs.Movie
{

    public class DeleteMovieDto
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
    }

}
