using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalonBookingSystem.Models
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("phone")]
        public string?   Phone { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("designation")]
        public string? Designation { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        [BsonElement("skill_ids")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> SkillIds { get; set; } = new List<string>();
    }
}
