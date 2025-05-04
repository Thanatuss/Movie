using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces.JWT
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
