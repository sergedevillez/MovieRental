using ADOLibrary;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class AuthService
    {
        private readonly Connection _connection;
        private readonly TokenService _tokenService;

        public AuthService(Connection connection)
        {
            _connection = connection;
        }

        public void Register(Customer customer)
        {
            Command cmd = new Command("RegisterUser", true);
            cmd.AddParameter("FirstName", customer.firstName);
            cmd.AddParameter("LastName", customer.lastName);
            cmd.AddParameter("Email", customer.email);
            cmd.AddParameter("Passwd", customer.passwd);
            _connection.ExecuteNonQuery(cmd);
            customer.passwd = null;
        }

        private Customer Convert(IDataReader reader)
        {
            return new Customer()
            {
                id = (int)reader["CustomerId"],
                //Il est préférable de mettre (string) plutôt que .ToString 
                //Car (reader["machin"] is DBNull) ? null : (string)reader["machin"]
                firstName = (string)reader["FirstName"],
                lastName = (string)reader["LastName"],
                email = (string)reader["Email"]
            };
        }
        public Customer Login(Customer customer)
        {
            Command cmd = new Command("CheckUser", true);
            cmd.AddParameter("Email", customer.email);
            cmd.AddParameter("Passwd", customer.passwd);
            // TODO : Prob. need firstname/lastname ?
            return _connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }
    }
}
