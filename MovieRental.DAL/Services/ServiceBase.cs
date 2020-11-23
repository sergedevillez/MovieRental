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
            //this.Connection = connection;
            this.Connection = new Connection(@"Data Source=DESKTOP-PJ4VH9N;Initial Catalog=MovieRental;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        public abstract TKey Insert(TEntity entity);
        public abstract TEntity Get(int key);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract bool Update(TEntity entity);
        public abstract bool Delete(TKey key);
    }
}
