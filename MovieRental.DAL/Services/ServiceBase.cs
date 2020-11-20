using ADOLibrary;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.DAL.Services
{
    public abstract class ServiceBase<TKey, TEntity> : IService<TKey, TEntity> 
        where TEntity : IEntity<TKey>
    {
        //Crud basic abstract + connection.

        protected Connection Connection { get; private set; }
        public ServiceBase(Connection connection)
        {
            this.Connection = connection;
            //connection = new Connection(@"stringConnection toward database");

        }

        public abstract TKey Insert(TEntity entity);
        public abstract TEntity Get(int key);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract bool Update(TEntity entity);
        public abstract bool Delete(TKey key);
    }
}
