using OnlineBooking.Web.Interfaces;
using OnlineBooking.Web.Models;

namespace OnlineBooking.Web.Repositories
{
    public class StylistRepository : GenericRepository<Stylist>, IStylistRepository
    {
        public StylistRepository(DbContext context) : base(context)
        {
        }
    }
}
