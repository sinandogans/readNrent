using AuthorTranslatorService.Domain.Abstraction.Entity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AuthorTranslatorService.Domain.Entities
{
    public class User : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
