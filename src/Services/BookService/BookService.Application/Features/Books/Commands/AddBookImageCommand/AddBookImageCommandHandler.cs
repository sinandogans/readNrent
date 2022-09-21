using AutoMapper;
using BookService.Application.Abstraction.Infrastructure.FileOperations;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookImageCommand
{
    public class AddBookImageCommandHandler : IRequestHandler<AddBookImageCommandRequest, AddBookImageCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileHelper _fileHelper;
        private readonly IMapper _mapper;

        public AddBookImageCommandHandler(IBookRepository bookRepository, IFileHelper fileHelper, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<AddBookImageCommandResponse> Handle(AddBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            var imagePath = _fileHelper.AddImageToProject(request.Image);
            BookImage bookImageToAdd = new()
            {
                Id = Guid.NewGuid(),
                Path = imagePath,
                BookId = request.BookId
            };

            await _bookRepository.AddBookImage(bookImageToAdd);
            var response = _mapper.Map<AddBookImageCommandResponse>(bookImageToAdd);
            return response;
        }
    }
}
