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
            Feature = new TranslatorFeature();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public TranslatorFeature Feature { get; set; }

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
