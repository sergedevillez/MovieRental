using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public ActorService(Connection connection)
            : base(connection) { }


        public override int Insert(Actor entity)
        {
            Command cmd = new Command("AddActor", true);
            cmd.AddParameter("FirstName", entity.firstName);
            cmd.AddParameter("LastName", entity.lastName);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Actor Get(int key)
        {
            Command cmd = new Command("GetActor", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Actor> GetAll()
        {
            Command cmd = new Command("GetAllActor", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Actor entity)
        {
            Command cmd = new Command("UpdateActor", true);
            cmd.AddParameter("Id", entity.id);
            cmd.AddParameter("LastName", entity.firstName);
            cmd.AddParameter("FirstName", entity.lastName);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteActor", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        
    }
}
