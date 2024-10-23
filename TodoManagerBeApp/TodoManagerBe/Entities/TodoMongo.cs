using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TodoManagerBe.Entities
{
    public class TodoMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Title")]
        public string? Title { get; set; }
        [BsonElement("IsCompleted")]
        public bool IsCompleted { get; set; }
        [BsonElement("Priority")]
        public double? Priority { get; set; }
    }
}
