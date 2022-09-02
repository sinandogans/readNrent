using BookService.Domain.Abstraction;
using System.Text.Json.Serialization;

namespace BookService.Domain.Entities
{
    public class Genre : IEntity
    {
        public Genre()
        {
            Books = new HashSet<Book>();
            SubGenres = new HashSet<Genre>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [JsonIgnore]
        public Genre Parent { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
        [JsonIgnore]
        public ICollection<Genre> SubGenres { get; set; }
    }
}