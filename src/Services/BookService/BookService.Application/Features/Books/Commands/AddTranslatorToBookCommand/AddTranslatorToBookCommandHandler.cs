using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddTranslatorToBookCommand
{
    public class AddTranslatorToBookCommandHandler : IRequestHandler<AddTranslatorToBookCommandRequest, AddTranslatorToBookCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddTranslatorToBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddTranslatorToBookCommandResponse> Handle(AddTranslatorToBookCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedBook = await _bookRepository.AddTranslator(request.BookId, request.TranslatorId);
            var response = _mapper.Map<AddTranslatorToBookCommandResponse>(updatedBook);
            return response;
        }
    }
}
