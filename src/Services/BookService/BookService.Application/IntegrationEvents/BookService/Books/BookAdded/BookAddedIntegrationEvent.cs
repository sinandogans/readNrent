namespace BookService.Application.IntegrationEvents.BookService.Books.BookAdded;

public class BookAddedIntegrationEvent : IntegrationEvent
{
    public Guid BookId { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public double Rating { get; set; }
}