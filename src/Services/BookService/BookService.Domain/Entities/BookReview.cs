using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class BookReview : IEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public Book Book { get; set; }
    }
}