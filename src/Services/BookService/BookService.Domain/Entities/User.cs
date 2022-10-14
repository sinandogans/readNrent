using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class User : IEntity
    {
        public User()
        {
            UserBooks = new List<UserBook>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int BookCount { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
