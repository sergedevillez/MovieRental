
using MovielRental.Models.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovielRental.Models.Services
{
    public class AuthService : IAuthService
    {
        private CustomerService _customerService;
        public bool Check(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Login(string email, string passwd)
        {
            Customer bob = new Customer();
            bob.email = email;
            bob.passwd = passwd;
            return _customerService.Login(bob);
        }

        public int Register(Customer customer)
        {
            return _customerService.Insert(customer);
        }

        public AuthService()
        {
            _customerService = new CustomerService();
        }
    }
}
