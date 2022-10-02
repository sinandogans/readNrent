using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class BookImage : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Path { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid BookId { get; set; }
    }
}