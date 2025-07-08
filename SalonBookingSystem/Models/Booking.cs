using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalonBookingSystem.Models
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("staff_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? StaffId { get; set; }

        [BsonElement("service_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ServiceId { get; set; }

        [BsonElement("date")]
        public string? Date { get; set; }

        [BsonElement("time")]
        public string? Time { get; set; }

        [BsonElement("status")]
        public StatusDetail Status { get; set; }

        [BsonElement("payment")]
        public PaymentDetail Payment { get; set; }
    }

    public class StatusDetail
    {
        [BsonElement("status_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? StatusId { get; set; }

        [BsonElement("category")]
        public string? Category { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }
    }

    public class PaymentDetail
    {
        [BsonElement("amount")]
        public int Amount { get; set; }

        [BsonElement("method")]
        public string? Method { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }
    }
}
