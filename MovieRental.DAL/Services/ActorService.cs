using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class ActorService : ServiceBase<int, Actor>
    {
        private Actor Convert(SqlDataReader reader)
        {
            return new Actor(
                (int)reader["Id"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString()
            );
        }


    }
}
