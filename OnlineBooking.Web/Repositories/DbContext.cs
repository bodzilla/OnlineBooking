using MongoDB.Driver;
using OnlineBooking.Web.Interfaces;

namespace OnlineBooking.Web.Repositories
{
    public class DbContext
    {
        public readonly IMongoDatabase Database;

        public DbContext(IDbContextSettings settings)
            => Database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
    }
}
