namespace OnlineBooking.Web.Interfaces
{
    public interface IOnlineBookingDatabaseSettings
    {
        string StylistsCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
