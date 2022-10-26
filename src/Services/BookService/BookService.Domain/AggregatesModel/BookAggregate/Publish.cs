using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BookService.Domain.Enums;

namespace BookService.Domain.AggregatesModel.BookAggregate
{
    public class Publish : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime PublishDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid PublisherId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid BookId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Language Language { get; set; }
    }
}