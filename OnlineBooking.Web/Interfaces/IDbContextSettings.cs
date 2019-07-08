namespace OnlineBooking.Web.Interfaces
{
    public interface IDbContextSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
