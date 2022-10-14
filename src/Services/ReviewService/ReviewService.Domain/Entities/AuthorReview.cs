using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReviewService.Domain.Abstraction;

namespace ReviewService.Domain.Entities
{
    public class AuthorReview : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public string Comment { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid AuthorId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }
    }
}
