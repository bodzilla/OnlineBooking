using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistService
    {
        Task<IEnumerable<Stylist>> GetAll();

        Task<IEnumerable<Stylist>> GetList(Expression<Func<Stylist, bool>> predicate);

        Task<Stylist> Get(string id);

        Task<bool> Exists(string id);

        Task<Stylist> Create(Stylist entity);

        Task<bool> Update(string id, Stylist entity);

        Task<bool> Remove(string id);
    }
}