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
                (int)reader["ActorId"],
                reader["FirstName"].ToString(),
                reader["LastName"].ToString()
            );
        }

        private string ConvertString(SqlDataReader reader)
        {
            return reader.ToString();
        }



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
            cmd.AddParameter("ActorId", key);

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
            cmd.AddParameter("ActorId", entity.id);
            cmd.AddParameter("LastName", entity.firstName);
            cmd.AddParameter("FirstName", entity.lastName);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteActor", true);
            cmd.AddParameter("ActorId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        //Add a film to "this" actor
        public bool AddFilmToActor(int keyActor, int keyFilm)
        {
            Command cmd = new Command("AddFilmToActor", true);
            cmd.AddParameter("ActorId", keyActor);
            cmd.AddParameter("FilmId", keyFilm);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        //Get ALL actor initials
        public IEnumerable<string> GetAllInitials()
        {
            Command cmd = new Command("GetActorInitiales", true);
            return Connection.ExecuteReader(cmd, ConvertString);
        }
    }
}
