using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class FilmService : ServiceBase<int, Film>
    {
        private Film Convert(SqlDataReader reader)
        {
            return new Film(
                (int)reader["FilmId"],
                reader["Title"].ToString(), 
                reader["Description"].ToString(),
                (int)reader["ReleaseYear"], 
                (int)reader["LanguageId"], 
                (int)reader["RentalDuration"], 
                (decimal)reader["RentalPrice"], //Might have a problem going from decimal (5,2) to double
                (int)reader["Lenght"], 
                (decimal)reader["ReplacementCost"], 
                (int)reader["RatingId"]
            );
        }

        public FilmService(Connection connection)
            : base(connection) { }


        public override int Insert(Film entity)
        {
            Command cmd = new Command("AddFilm", true);
            cmd.AddParameter("Title", entity.title);
            cmd.AddParameter("Description", entity.description);
            cmd.AddParameter("ReleaseYear", entity.releaseYear);
            cmd.AddParameter("LanguageId", entity.languageId);
            cmd.AddParameter("RentalDuration", entity.rentalDuration);
            cmd.AddParameter("RentalPrice", entity.rentalPrice);
            cmd.AddParameter("Length", entity.length);
            cmd.AddParameter("ReplacementCost", entity.replacementCost);
            cmd.AddParameter("RatingId", entity.ratingId);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Film Get(int key)
        {
            Command cmd = new Command("GetFilm", true);
            cmd.AddParameter("FilmId", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Film> GetAll()
        {
            Command cmd = new Command("GetAllFilm", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Film entity)
        {
            Command cmd = new Command("UpdateFilm", true);
            cmd.AddParameter("FilmId", entity.id);
            cmd.AddParameter("Title", entity.title);
            cmd.AddParameter("Description", entity.description);
            cmd.AddParameter("ReleaseYear", entity.releaseYear);
            cmd.AddParameter("LanguageId", entity.languageId);
            cmd.AddParameter("RentalDuration", entity.rentalDuration);
            cmd.AddParameter("RentalPrice", entity.rentalPrice);
            cmd.AddParameter("Length", entity.length);
            cmd.AddParameter("ReplacementCost", entity.replacementCost);
            cmd.AddParameter("RatingId", entity.ratingId);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteFilm", true);
            cmd.AddParameter("FilmId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        //Add an actor to "this" movie
        public bool AddActorToFilm(int keyFilm, int keyActor)
        {
            Command cmd = new Command("AddActorToFilm", true);
            cmd.AddParameter("FilmId", keyFilm);
            cmd.AddParameter("ActorId", keyActor);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        //Add a category to "this" film
        //They are no "add film to category". TODO :  To modify or not ?
        public bool AddCategoryToFilm(int keyFilm, int keyCategory)
        {
            Command cmd = new Command("AddCategoryToFilm", true);
            cmd.AddParameter("FilmId", keyFilm);
            cmd.AddParameter("ActorId", keyCategory);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
