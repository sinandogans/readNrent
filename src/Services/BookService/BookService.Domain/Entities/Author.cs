using BookService.Domain.Abstraction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookService.Domain.Entities
{
    public class Author : IEntity
    {
        public Author()
        {
            ReviewIds = new List<Guid>();
            BookIds = new List<Guid>();
            Feature = new AuthorFeature();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public AuthorFeature Feature { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> ReviewIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> BookIds { get; set; }
    }
}
