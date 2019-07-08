using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate);

        Task<T> Get(string id);

        Task<bool> Exists(string id);

        Task<T> Create(T entity);

        Task<bool> Update(string id, T entity);

        Task<bool> Remove(string id);
    }
}