using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Services
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _repository;

        public StylistService(IStylistRepository repository) => _repository = repository;

        public async Task<IEnumerable<Stylist>> GetAll() => await _repository.GetAll().ConfigureAwait(false);

        public async Task<IEnumerable<Stylist>> GetList(Expression<Func<Stylist, bool>> predicate) => await _repository.GetList(predicate).ConfigureAwait(false);

        public async Task<Stylist> Get(string id) => await _repository.Get(id).ConfigureAwait(false);

        public async Task<bool> Exists(string id) => await _repository.Exists(id).ConfigureAwait(false);

        public async Task<Stylist> Create(Stylist stylist) => await _repository.Create(stylist).ConfigureAwait(false);

        public async Task<bool> Update(string id, Stylist stylist) => await _repository.Update(id, stylist).ConfigureAwait(false);

        public async Task<bool> Remove(string id) => await _repository.Remove(id).ConfigureAwait(false);
    }
}
