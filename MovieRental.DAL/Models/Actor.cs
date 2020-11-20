using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Actor : IEntity<int>
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Actor() { }
        public Actor(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        internal Actor(int id, string firstName, string lastName)
            :this(firstName, lastName)
        {
            this.id = id;
        }

        
    }
}
