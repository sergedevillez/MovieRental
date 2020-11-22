using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieRental.DAL.Services
{
    public class CategoryService : ServiceBase<int, Category>
    {
        private Category Convert(SqlDataReader reader)
        {
            return new Category(
                (int)reader["CategoryId"],
                reader["Name"].ToString()
            );
        }

        public CategoryService(Connection connection)
            : base(connection) { }


        public override int Insert(Category entity)
        {
            Command cmd = new Command("AddCategory", true);
            cmd.AddParameter("Name", entity.name);

            return (int)Connection.ExecuteScalar(cmd);
        }

        public override Category Get(int key)
        {
            Command cmd = new Command("GetCatgory", true);
            cmd.AddParameter("VategoryId", key);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override IEnumerable<Category> GetAll()
        {
            Command cmd = new Command("GetAllCategory", true);
            return Connection.ExecuteReader(cmd, Convert);
        }

        public override bool Update(Category entity)
        {
            Command cmd = new Command("UpdateCategory", true);
            cmd.AddParameter("CategoryId", entity.id);
            cmd.AddParameter("Name", entity.name);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public override bool Delete(int key)
        {
            Command cmd = new Command("DeleteCategory", true);
            cmd.AddParameter("CategoryId", key);

            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
