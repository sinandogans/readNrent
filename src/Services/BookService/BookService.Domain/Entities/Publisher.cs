using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class Publisher : IEntity
    {
        public Publisher()
        {
            PublishIds = new List<Guid>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> PublishIds { get; set; }
    }
}