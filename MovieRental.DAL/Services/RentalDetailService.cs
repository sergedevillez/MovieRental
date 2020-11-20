using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class RentalDetailService
    {
        protected Connection Connection { get; private set; }
        private RentalDetail Convert(SqlDataReader reader)
        {
            return new RentalDetail(
                (int)reader["CustomerId"],
                (int)reader["FilmId"],
                (int)reader["RentalPrice"]
            );
        }

        public RentalDetailService(Connection connection)
        {
            Connection = connection;
        }


        public int Insert(RentalDetail entity)
        {
            Command cmd = new Command("AddRentalDetail", true);
            cmd.AddParameter("CustomerId", entity.customerId);
            cmd.AddParameter("FilmId", entity.filmId);
            cmd.AddParameter("RentalPrice", entity.rentalPrice);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public RentalDetail Get(int key)
        {
            Command cmd = new Command("GetRentalDetail", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<RentalDetail> GetAll()
        {
            Command cmd = new Command("GetAllRentalDetail", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public bool Update(RentalDetail entity)
        {
            Command cmd = new Command("UpdateRentalDetail", true);
            cmd.AddParameter("CustomerId", entity.customerId);
            cmd.AddParameter("FilmId", entity.filmId);
            cmd.AddParameter("RentalPrice", entity.rentalPrice);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int key1, int key2)
        {
            Command cmd = new Command("DeleteRentalDetail", true);
            cmd.AddParameter("CustomerId", key1);
            cmd.AddParameter("FilmId", key2);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
