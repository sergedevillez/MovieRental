using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Customer : IEntity<int>
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string passwd { get; set; }
        public string Token { set; get; }

        public Customer() { }
        public Customer(string firstName, string lastName, string email, string passwd)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.passwd = passwd;
        }
        
        public Customer(int id, string firstName, string lastName, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
        internal Customer(int id, string firstName, string lastName, string email, string passwd)
        : this(firstName, lastName, email, passwd) //TODO : Check if we need to get back the passw here ? Seems unlikely.
        {
            this.id = id;
        }
    }
}
