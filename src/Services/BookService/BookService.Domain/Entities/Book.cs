using BookService.Domain.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookService.Domain.Entities
{
    public class Book : IEntity
    {
        public Book()
        {
            PublishIds = new List<Guid>();
            GenreIds = new List<Guid>();
            ImageIds = new List<Guid>();
            ReviewIds = new List<Guid>();
            AuthorIds = new List<Guid>();
            TranslatorIds = new List<Guid>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Pages { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReadCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int RatingCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReviewCount { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> PublishIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> GenreIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> ImageIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> ReviewIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> AuthorIds { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ICollection<Guid> TranslatorIds { get; set; }
    }
}
