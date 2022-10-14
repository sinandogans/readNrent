using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ReviewService.Domain.Abstraction;

namespace ReviewService.Domain.Entities
{
    public class User : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
