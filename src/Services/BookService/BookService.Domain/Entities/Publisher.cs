using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class Publisher : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Publish> Publishes { get; set; }
    }
}