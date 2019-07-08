using OnlineBooking.Web.Interfaces;

namespace OnlineBooking.Web.Models
{
    public class DbContextSettings : IDbContextSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
