using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.AggregatesModel.BookAggregate
{
    public class Genre : IEntity
    {
        public Genre()
        {
            SubGenreIds = new List<Guid>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid ParentId { get; set; } = default;

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> SubGenreIds { get; set; }
    }
}