using BookService.Application.Abstraction.Infrastructure.FileOperations;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookService.Application.Features.Books.Commands.AddBookImageCommand
{
    public class AddBookImageCommandRequest : IRequest<AddBookImageCommandResponse>
    {
        public IFormFile Image { get; set; }
        public Guid BookId { get; set; }
    }
    public class AddBookImageCommandHandler : IRequestHandler<AddBookImageCommandRequest, AddBookImageCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IFileHelper _fileHelper;

        public AddBookImageCommandHandler(IBookWriteRepository bookWriteRepository, IFileHelper fileHelper)
        {
            _bookWriteRepository = bookWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<AddBookImageCommandResponse> Handle(AddBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            var imagePath = _fileHelper.AddImageToProject(request.Image);
            BookImage bookImage = new()
            {
                Id = Guid.NewGuid(),
                Path = imagePath,
                BookId = request.BookId
            };

            await _bookWriteRepository.AddBookImage(request.BookId, bookImage);
            return new AddBookImageCommandResponse()
            {
                BookId = request.BookId,
                ImagePath = imagePath
            };
        }
    }
    public class AddBookImageCommandResponse
    {
        public string ImagePath { get; set; }
        public Guid BookId { get; set; }
    }
}
