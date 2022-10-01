using BookService.Domain.Abstraction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookService.Domain.Entities
{
    public class Translator : IEntity
    {
        public Translator()
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
        public ICollection<Guid> ReviewIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> BookIds { get; set; }

        //[BsonIgnore]

        //public List<TranslatorReview> Reviews { get; set; }
        //[BsonIgnore]

        //public List<Book> Books { get; set; }
    }
}
