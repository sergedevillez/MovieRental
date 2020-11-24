using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.API.Infrastructure.Security
{
    public interface ITokenService
    {
        string GenerateToken(Customer customer);
        Customer ValidateToken(string token);

    }
}
