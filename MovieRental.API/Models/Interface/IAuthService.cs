using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.API.Models.Interface
{
    public interface IAuthService
    {
        Customer Login(string email, string passwd);
        int Register(Customer customer);
    }
}
