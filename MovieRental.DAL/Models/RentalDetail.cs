using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class RentalDetail
    {
        public int customerId { get; set; }
        public int filmId { get; set; }
        public double rentalPrice { get; set; }

        public RentalDetail() { }
        public RentalDetail(int customerId, int filmId, double rentalPrice)
        {
            this.customerId = customerId;
            this.filmId = filmId;
            this.rentalPrice = rentalPrice;
        }
    }
}
