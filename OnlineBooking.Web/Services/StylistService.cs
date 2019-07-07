using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Services
{
    public class StylistService : IStylistService
    {
        private readonly IMongoCollection<Stylist> _stylists;

        public StylistService(IOnlineBookingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _stylists = database.GetCollection<Stylist>(settings.StylistsCollectionName);
        }

        public List<Stylist> GetAll() => _stylists.Find(x => true).ToList();

        public List<Stylist> GetList(Expression<Func<Stylist, bool>> predicate) => _stylists.Find(predicate).ToList();

        public Stylist Get(string id) => _stylists.Find(x => x.Id == id).FirstOrDefault();

        public Stylist Create(Stylist stylist)
        {
            _stylists.InsertOne(stylist);
            return stylist;
        }

        public void Update(string id, Stylist stylist) => _stylists.ReplaceOne(x => x.Id == id, stylist);

        public void Remove(Stylist stylist) => _stylists.DeleteOne(x => x.Id == stylist.Id);

        public void Remove(string id) => _stylists.DeleteOne(x => x.Id == id);
    }
}
