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

        public async Task<IEnumerable<Stylist>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<IEnumerable<Stylist>> GetListAsync(Expression<Func<Stylist, bool>> predicate) => await _repository.GetListAsync(predicate);

        public async Task<Stylist> GetAsync(string id) => await _repository.GetAsync(x => x.Id.Equals(id));

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(x => x.Id.Equals(id));

        public async Task<Stylist> CreateAsync(Stylist stylist) => await _repository.CreateAsync(stylist);

        public async Task<bool> UpdateAsync(string id, Stylist stylist) => await _repository.UpdateAsync(id, stylist);

        public async Task<bool> DeleteAsync(string id) => await _repository.DeleteAsync(id);
    }
}
