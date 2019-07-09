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
        protected readonly IMongoCollection<T> Collection;

        public GenericRepository(DbContext context) => Collection = context.Database.GetCollection<T>(typeof(T).Name);

        public async Task<IEnumerable<T>> GetAllAsync() => await Collection.Find(x => true).ToListAsync();

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate) => await Collection.Find(predicate).ToListAsync();

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate) => await Collection.Find(predicate).FirstOrDefaultAsync();

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => await GetAsync(predicate) != null;

        public async Task<T> CreateAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(string id, T entity)
        {
            var result = await Collection.ReplaceOneAsync(x => x.Id.Equals(id), entity);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await Collection.DeleteOneAsync(x => x.Id.Equals(id));
            return result.IsAcknowledged;
        }
    }
}
