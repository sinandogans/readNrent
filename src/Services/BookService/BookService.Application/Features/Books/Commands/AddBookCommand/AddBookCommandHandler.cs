using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, AddBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddBookCommandResponse> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var bookToAdd = _mapper.Map<Book>(request);
            bookToAdd.Id = Guid.NewGuid();

            await _bookWriteRepository.Add(bookToAdd);
            return _mapper.Map<AddBookCommandResponse>(bookToAdd);
        }
    }
}
