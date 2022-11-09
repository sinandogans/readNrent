using AutoMapper;
using BookService.Application.Abstraction.Infrastructure.EventBus;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.IntegrationEvents.BookService.Books.BookAdded;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.AggregatesModel.BookAggregate;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, IResponseModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IEventBus eventBus)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<IResponseModel> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var bookToAdd = _mapper.Map<Book>(request);
            bookToAdd.Id = Guid.NewGuid();

            await _bookRepository.Add(bookToAdd);

            var bookAddedEvent = _mapper.Map<BookAddedIntegrationEvent>(bookToAdd);
            _eventBus.Publish<BookAddedIntegrationEvent>(bookAddedEvent);
            
            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}