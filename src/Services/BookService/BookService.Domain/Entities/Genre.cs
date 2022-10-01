using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class Genre : IEntity
    {
        public Genre()
        {
            BookIds = new List<Guid>();
            SubGenreIds = new List<Guid>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid? ParentId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> BookIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> SubGenreIds { get; set; }
    }
}