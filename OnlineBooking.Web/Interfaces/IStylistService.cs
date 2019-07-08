﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Interfaces
{
    public interface IStylistService
    {
        IEnumerable<Stylist> GetAll();

        IEnumerable<Stylist> GetList(Expression<Func<Stylist, bool>> predicate);

        Stylist Get(string id);

        Stylist Create(Stylist stylist);

        void Update(string id, Stylist stylist);

        void Remove(string id);
    }
}