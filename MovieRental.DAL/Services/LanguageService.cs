using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class LanguageService : ServiceBase<int, Language>
    {
        private Language Convert(SqlDataReader reader)
        {
            return new Language(
                (int)reader["LanguageId"],
                reader["Name"].ToString()
            );
        }

        //public LanguageService(Connection connection)
        //    : base(connection) { }


        public override int Insert(Language entity)
        {
            Command cmd = new Command("AddLanguage", true);
            cmd.AddParameter("Name", entity.name);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Language Get(int key)
        {
            Command cmd = new Command("GetLanguage", true);
            cmd.AddParameter("LanguageId", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Language> GetAll()
        {
            Command cmd = new Command("GetAllLanguage", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Language entity)
        {
            Command cmd = new Command("UpdateLanguage", true);
            cmd.AddParameter("LanguageId", entity.id);
            cmd.AddParameter("Name", entity.name);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteLanguage", true);
            cmd.AddParameter("LanguageId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
