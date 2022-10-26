using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.AggregatesModel.UserAggregate
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookCount { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}
