using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class BookFeature
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Pages { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReadCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReviewCount { get; set; }
    }
}
