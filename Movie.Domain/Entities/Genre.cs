using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        
    }
}
