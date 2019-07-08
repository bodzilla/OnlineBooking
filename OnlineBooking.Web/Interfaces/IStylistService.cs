using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistService
    {
        Task<IEnumerable<Stylist>> GetAllAsync();

        Task<IEnumerable<Stylist>> GetListAsync(Expression<Func<Stylist, bool>> predicate);

        Task<Stylist> GetAsync(string id);

        Task<bool> ExistsAsync(string id);

        Task<Stylist> CreateAsync(Stylist entity);

        Task<bool> UpdateAsync(string id, Stylist entity);

        Task<bool> DeleteAsync(string id);
    }
}