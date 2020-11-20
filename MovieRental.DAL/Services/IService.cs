using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Services
{
    public interface IService<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        //CRUD basic
        TKey Insert(TEntity entity);
        TEntity Get(int key);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity entity);
        bool Delete(TKey key);
    }
}
