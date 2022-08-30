using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookLanguageCommand
{
    public class AddBookLanguageCommandHandler : IRequestHandler<AddBookLanguageCommandRequest, AddBookLanguageCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;

        public AddBookLanguageCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddBookLanguageCommandResponse> Handle(AddBookLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            await _bookWriteRepository.AddBookLanguage(request.BookId, request.LanguageId);
            return new AddBookLanguageCommandResponse();
        }
    }
}
