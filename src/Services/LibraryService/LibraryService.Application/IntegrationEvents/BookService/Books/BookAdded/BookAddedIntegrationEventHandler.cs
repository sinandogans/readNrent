using AutoMapper;
using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Domain.Abstraction.Repositories;
using LibraryService.Domain.AggregatesModel.LibraryAggregate;

namespace LibraryService.Application.IntegrationEvents.BookService.Books.BookAdded;

public class BookAddedIntegrationEventHandler : IIntegrationEventHandler<BookAddedIntegrationEvent>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookAddedIntegrationEventHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task Handle(BookAddedIntegrationEvent @event)
    {
        var bookToAdd = _mapper.Map<Book>(@event);
        await _bookRepository.Add(bookToAdd);
    }
}