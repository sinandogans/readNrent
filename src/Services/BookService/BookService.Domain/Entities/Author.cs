using BookService.Domain.Abstraction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookService.Domain.Entities
{
    public class Author : IEntity
    {
        public Author()
        {
            BookIds = new List<Guid>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int RatingCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReadCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReviewCount { get; set; }
        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> BookIds { get; set; }
    }
}
