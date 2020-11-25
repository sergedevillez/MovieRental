using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Infrastructures.Security
{
    public interface ITokenService
    {
        string GenerateToken(Customer customer);
        Customer ValidateToken(string token);

    }
}
