using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Rating : IEntity<int>
    {
        public int id { get; set;}
        public string rating { get; set; }

        public Rating() { }
        public Rating(string rating)
        {
            this.rating = rating;
        }
        internal Rating(int id, string rating)
            : this(rating)
        {
            this.id = id;
        }
    }
}
