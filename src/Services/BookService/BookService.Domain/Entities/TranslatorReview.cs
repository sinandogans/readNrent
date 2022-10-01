using BookService.Domain.Abstraction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookService.Domain.Entities
{
    public class TranslatorReview : IEntity
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
        public Guid TranslatorId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid UserId { get; set; }

        //[BsonIgnore]

        //public User User { get; set; }
        //[BsonIgnore]

        //public Translator Translator { get; set; }
    }
}
