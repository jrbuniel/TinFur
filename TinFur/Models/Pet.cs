using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TinFur.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
    }
}
