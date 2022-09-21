using BookService.Domain.Abstraction;
using System.Text.Json.Serialization;

namespace BookService.Domain.Entities
{
    public class AuthorModel : IEntity
    {
        public AuthorModel()
        {
            Books = new HashSet<Book>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }

    }
}
