using ADOLibrary;
using MovieRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MovieRental.DAL.Models
{
    class RentalDetail : ServiceBase<int, Rental>
    {


        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Rental> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Rental Get(int key)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Rental entity)
        {
            throw new NotImplementedException();

        }

        public override bool Update(Rental entity)
        {
            throw new NotImplementedException();
        }



    }
}