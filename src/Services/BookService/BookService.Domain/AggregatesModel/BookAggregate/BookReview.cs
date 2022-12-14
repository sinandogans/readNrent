using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.AggregatesModel.BookAggregate
{
    public class BookReview : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Comment { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid BookId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
    }
}