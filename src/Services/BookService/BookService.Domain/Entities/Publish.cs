using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class Publish : IEntity
    {
        public Guid Id { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}