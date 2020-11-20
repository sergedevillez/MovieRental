using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Models
{
    public interface IEntity<TKey>
    {
        TKey id { get; }
    }
}
