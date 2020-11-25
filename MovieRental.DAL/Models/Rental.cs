using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Rental : IEntity<int>
    {
        public int id { get; set; }
        public DateTime rentalDate { get; set; }
        public int customerId { get; set; }

        public Rental(DateTime rentalDate, int customerId)
        {
            this.rentalDate = rentalDate;
            this.customerId = customerId;
        }
        internal Rental(int id, DateTime rentalDate, int customerId)
            : this(rentalDate, customerId)
        {
            this.id = id;
        }
    }
}
