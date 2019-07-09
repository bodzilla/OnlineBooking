using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistRepository
    {
        Task<IEnumerable<Stylist>> GetAllAsync();

        Task<IEnumerable<Stylist>> GetListAsync(Expression<Func<Stylist, bool>> predicate);

        Task<Stylist> GetAsync(Expression<Func<Stylist, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<Stylist, bool>> predicate);

        Task<Stylist> CreateAsync(Stylist entity);

        Task<bool> UpdateAsync(string id, Stylist entity);

        Task<bool> DeleteAsync(string id);
    }
}