using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(string id);

        Task<bool> ExistsAsync(string id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(string id, T entity);

        Task<bool> DeleteAsync(string id);
    }
}