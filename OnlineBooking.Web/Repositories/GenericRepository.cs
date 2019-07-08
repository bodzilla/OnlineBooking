using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(DbContext dbContext) => _collection = dbContext.Database.GetCollection<T>(typeof(T).Name);

        public async Task<IEnumerable<T>> GetAll() => await _collection.Find(x => true).ToListAsync().ConfigureAwait(false);

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate) => await _collection.Find(predicate).ToListAsync().ConfigureAwait(false);

        public async Task<T> Get(string id) => await _collection.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().ConfigureAwait(false);

        public async Task<bool> Exists(string id) => await Get(id).ConfigureAwait(false) != null;

        public async Task<T> Create(T entity)
        {
            await _collection.InsertOneAsync(entity).ConfigureAwait(false);
            return entity;
        }

        public async Task<bool> Update(string id, T entity)
        {
            var result = await _collection.ReplaceOneAsync(x => x.Id.Equals(id), entity).ConfigureAwait(false);
            return result.IsAcknowledged;
        }

        public async Task<bool> Remove(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            return result.IsAcknowledged;
        }
    }
}
