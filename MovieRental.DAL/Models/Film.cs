using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public class Film : IEntity<int>
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; } //NULLABLE automatique because string
        public int? releaseYear { get; set; } //NULLABLE to add since value
        public int languageId { get; set; }
        public int rentalDuration { get; set; }
        public double rentalPrice { get; set; }
        public int? length { get; set; } //NULLABLE
        public double replacementCost { get; set; }
        public int ratingId { get; set; }

        public Film() { }
        public Film(string title, string description, int? releaseYear, int languageId, int rentalDuration, double rentalPrice, int? lenght, double replacementCost, int ratingId)
        {
            this.title = title;
            this.description = description;
            this.releaseYear = releaseYear;
            this.languageId = languageId;
            this.rentalDuration = rentalDuration;
            this.rentalPrice = rentalPrice;
            this.length = lenght;
            this.replacementCost = replacementCost;
            this.ratingId = ratingId;
        }
        internal Film(int id, string title, string description, int? releaseYear, int languageId, int rentalDuration, double rentalPrice, int? lenght, double replacementCost, int ratingId)
            : this( title,  description, releaseYear,  languageId,  rentalDuration,  rentalPrice, lenght,  replacementCost, ratingId)
        {
            this.id = id;
        }
    }
}
