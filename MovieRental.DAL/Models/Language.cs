using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Language : IEntity<int>
    {
        public int id { get; set; }
        public string name { get; set; }

        public Language() { }
        public Language(string name)
        {
            this.name = name;
        }
        internal Language(int id, string name)
            : this(name)
        {
            this.id = id;
        }
    }
}
