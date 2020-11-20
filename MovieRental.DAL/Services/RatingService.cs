using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class RatingService : ServiceBase<int, Rating>
    {
        private Rating Convert(SqlDataReader reader)
        {
            return new Rating(
                (int)reader["Id"],
                reader["Rating"].ToString()
            );
        }

        public RatingService(Connection connection)
            : base(connection) { }


        public override int Insert(Rating entity)
        {
            Command cmd = new Command("AddRating", true);
            cmd.AddParameter("Rating", entity.rating);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Rating Get(int key)
        {
            Command cmd = new Command("GetRating", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Rating> GetAll()
        {
            Command cmd = new Command("GetAllRating", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Rating entity)
        {
            Command cmd = new Command("UpdateRating", true);
            cmd.AddParameter("Id", entity.id);
            cmd.AddParameter("Rating", entity.rating);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteRating", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
