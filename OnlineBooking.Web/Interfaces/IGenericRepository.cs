using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);

        T Get(string id);

        T Create(T entity);

        void Update(string id, T entity);

        void Remove(string id);
    }
}