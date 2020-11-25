using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class RentalService : ServiceBase<int, Rental>
    {

        public int Insertion(Rental entity, int[] films)
        {
            DataTable filma = new DataTable();
            filma.Columns.Add(new DataColumn("Id", typeof(int)));

            foreach (int t in films)
            {
                filma.Rows.Add(t);
            }
            Command cmd = new Command("CreateRental", true);
            cmd.AddParameter("CustomerId", entity.CustomerId);
            cmd.AddParameter("FilmIds", filma);
            return Connection.ExecuteNonQuery(cmd);
        }


        private Rental Convert(SqlDataReader reader)
        {
            return new Rental(
                (int)reader["RentalId"],
                (DateTime)reader["RentalDate"],
                (int)reader["CustomerId"]
            );
        }


        public override int Insert(Rental entity)
        {
            Command cmd = new Command("AddRental", true);
            cmd.AddParameter("RentalDate", entity.RentalDate);
            cmd.AddParameter("CustomerId", entity.CustomerId);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Rental Get(int key)
        {
            Command cmd = new Command("GetRental", true);
            cmd.AddParameter("RentalId", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Rental> GetAll()
        {
            Command cmd = new Command("GetAllRental", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Rental entity)
        {
            Command cmd = new Command("UpdateRental", true);
            cmd.AddParameter("RentalId", entity.id);
            cmd.AddParameter("RentalDate", entity.RentalDate);
            cmd.AddParameter("CustomerId", entity.CustomerId);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteRental", true);
            cmd.AddParameter("RentalId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
