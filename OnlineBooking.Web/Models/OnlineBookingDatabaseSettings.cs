using OnlineBooking.Web.Interfaces;

namespace OnlineBooking.Web.Models
{
    public class OnlineBookingDatabaseSettings : IOnlineBookingDatabaseSettings
    {
        public string StylistsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
