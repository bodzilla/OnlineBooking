using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Services
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _repository;

        public StylistService(IStylistRepository repository) => _repository = repository;

        public IEnumerable<Stylist> GetAll() => _repository.GetAll();

        public IEnumerable<Stylist> GetList(Expression<Func<Stylist, bool>> predicate) => _repository.GetList(predicate);

        public Stylist Get(string id) => _repository.Get(id);

        public Stylist Create(Stylist stylist) => _repository.Create(stylist);

        public void Update(string id, Stylist stylist) => _repository.Update(id, stylist);

        public void Remove(string id) => _repository.Remove(id);
    }
}
