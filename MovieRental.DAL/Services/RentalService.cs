using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class RentalService : ServiceBase<int, Rental>
    {
        private Film Convert(SqlDataReader reader)
        {
            return new Film(
                (int)reader["Id"],
                reader["Title"].ToString(),
                reader["Description"].ToString(),
                (int)reader["ReleaseYear"],
                (int)reader["LanguageId"],
                (int)reader["RentalDuration"],
                (double)reader["RentalPrice"],
                (int)reader["Lenght"],
                (double)reader["ReplacementCost"],
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
            cmd.AddParameter("Id", key);

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
            cmd.AddParameter("Id", entity.id);
            cmd.AddParameter("Title", entity.title);
            cmd.AddParameter("Description", entity.description);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteFilm", true);
            cmd.AddParameter("Id", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
