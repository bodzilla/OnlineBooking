using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistRepository
    {
        IEnumerable<Stylist> GetAll();

        IEnumerable<Stylist> GetList(Expression<Func<Stylist, bool>> predicate);

        Stylist Get(string id);

        Stylist Create(Stylist entity);

        void Update(string id, Stylist entity);

        void Remove(string id);
    }
}