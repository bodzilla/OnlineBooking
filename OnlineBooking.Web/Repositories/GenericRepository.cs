using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(DbContext dbContext) => _collection = dbContext.Database.GetCollection<T>(typeof(T).Name);

        public IEnumerable<T> GetAll() => _collection.Find(x => true).ToEnumerable();

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate) => _collection.Find(predicate).ToEnumerable();

        public T Get(string id) => _collection.Find(x => x.Id.Equals(id)).FirstOrDefault();

        public T Create(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public void Update(string id, T entity) => _collection.ReplaceOne(x => x.Id.Equals(id), entity);

        public void Remove(string id) => _collection.DeleteOne(x => x.Id.Equals(id));
    }
}
