using BookService.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class UserBook
    {
        [BsonRepresentation(BsonType.String)]
        public Guid BookId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime BeginDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public int Rating { get; set; }
    }
}
