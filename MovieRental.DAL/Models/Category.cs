using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Category : IEntity<int>
    {
        public int id { get; set; }
        public string name { get; set; }

        public Category() { }
        public Category(string name)
        {
            this.name = name;
        }
        internal Category(int id, string name)
            : this(name)
        {
            this.id = id;
        }
    }
}
