using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class AuthorFeature
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReadCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReviewCount { get; set; }
    }
}
