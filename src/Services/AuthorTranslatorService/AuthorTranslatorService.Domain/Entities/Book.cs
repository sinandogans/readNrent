using AuthorTranslatorService.Domain.Abstraction.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AuthorTranslatorService.Domain.Entities
{
    public class Book : IEntity
    {
        public Book()
        {
            AuthorIds = new List<Guid>();
            TranslatorIds = new List<Guid>();

        }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.Double)]

        public double Rating { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [BsonRepresentation(BsonType.String)]

        public List<Guid> AuthorIds { get; set; }
        [BsonRepresentation(BsonType.String)]

        public List<Guid> TranslatorIds { get; set; }
        [BsonIgnore]

        public List<Author> Authors { get; set; }
        [BsonIgnore]

        public List<Translator> Translators { get; set; }
    }
}
