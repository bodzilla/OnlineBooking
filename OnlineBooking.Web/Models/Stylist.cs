using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineBooking.Web.Models
{
    public class Stylist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Salon { get; set; }
    }
}
