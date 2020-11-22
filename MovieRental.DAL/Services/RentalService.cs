﻿using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class RentalService : ServiceBase<int, Rental>
    {
        private Rental Convert(SqlDataReader reader)
        {
            return new Rental(
                (int)reader["RentalId"],
                (DateTime)reader["RentalDate"],
                (int)reader["CustomerId"]
            );
        }

        public RentalService(Connection connection)
            : base(connection) { }


        public override int Insert(Rental entity)
        {
            Command cmd = new Command("AddRental", true);
            cmd.AddParameter("RentalDate", entity.rentalDate);
            cmd.AddParameter("CustomerId", entity.customerId);

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
            cmd.AddParameter("RentalDate", entity.rentalDate);
            cmd.AddParameter("CustomerId", entity.customerId);

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
