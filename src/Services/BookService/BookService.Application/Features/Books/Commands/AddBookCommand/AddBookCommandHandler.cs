using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, AddBookCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddBookCommandResponse> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = _mapper.Map<BookFeature>(request);
            var bookToAdd = new Book();
            bookToAdd.Id = Guid.NewGuid();
            bookToAdd.Feature = feature;

            await _bookRepository.Add(bookToAdd);
            return new AddBookCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
