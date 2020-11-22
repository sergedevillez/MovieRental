using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class CustomerService : ServiceBase<int, Customer>
    {
        private Customer Convert(SqlDataReader reader)
        {
            return new Customer(
                (int)reader["CustomerId"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["Email"].ToString(),
                reader["Passwd"].ToString()//TODO : Take off the passw because it cannot leave the database.
            );
        }

        public CustomerService(Connection connection)
            : base(connection) { }


        public override int Insert(Customer entity)
        {
            Command cmd = new Command("AddCustomer", true);
            cmd.AddParameter("FirstName", entity.firstName);
            cmd.AddParameter("LastName", entity.lastName);
            cmd.AddParameter("Email", entity.email);
            cmd.AddParameter("Passwd", entity.passwd);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Customer Get(int key)
        {
            Command cmd = new Command("GetCustomer", true);
            cmd.AddParameter("CustomerId", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Customer> GetAll()
        {
            Command cmd = new Command("GetAllCustomer", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Customer entity)
        {
            Command cmd = new Command("UpdateCustomer", true);
            cmd.AddParameter("CustomerId", entity.id);
            cmd.AddParameter("FirstName", entity.firstName);
            cmd.AddParameter("LastName", entity.lastName);
            cmd.AddParameter("Email", entity.email);
            cmd.AddParameter("Passwd", entity.passwd); //TODO : Maybe create a special methode/service only for modifying the passwd.

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteCustomer", true);
            cmd.AddParameter("CustomerId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
