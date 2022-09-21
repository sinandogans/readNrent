using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddAuthorToBookCommand
{
    public class AddAuthorToBookCommandHandler : IRequestHandler<AddAuthorToBookCommandRequest, AddAuthorToBookCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddAuthorToBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddAuthorToBookCommandResponse> Handle(AddAuthorToBookCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedBook = await _bookRepository.AddAuthor(request.BookId, request.AuthorId);
            var response = _mapper.Map<AddAuthorToBookCommandResponse>(updatedBook);
            return response;
        }
    }
}
