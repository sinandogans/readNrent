using AuthorTranslatorService.Domain.Abstraction.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthorTranslatorService.Domain.Entities
{
    public class Author : IEntity
    {
        public Author()
        {
            ReviewIds = new List<Guid>();
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
        public int ReviewCount { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<Guid> ReviewIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<Guid> BookIds { get; set; }

        [BsonIgnore]
        public List<AuthorReview> Reviews { get; set; }

        [BsonIgnore]
        public List<Book> Books { get; set; }
    }
}
