using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistService
    {
        List<Stylist> GetAll();

        List<Stylist> GetList(Expression<Func<Stylist, bool>> predicate);

        Stylist Get(string id);

        Stylist Create(Stylist stylist);

        void Update(string id, Stylist stylist);

        void Remove(Stylist stylist);

        void Remove(string id);
    }
}