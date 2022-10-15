using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, IResponseModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var bookToAdd = _mapper.Map<Book>(request);
            bookToAdd.Id = Guid.NewGuid();

            await _bookRepository.Add(bookToAdd);
            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
