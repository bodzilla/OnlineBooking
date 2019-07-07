using MongoDB.Driver;
using OnlineBooking.Web.Interfaces;

namespace OnlineBooking.Web.Models
{
    public class Database
    {
        protected readonly IMongoDatabase Source;

        public Database(IOnlineBookingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            Source = client.GetDatabase(settings.DatabaseName);
        }
    }
}
