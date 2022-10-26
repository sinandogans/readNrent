using AutoMapper;
using BookService.Application.Abstraction.Infrastructure.FileOperations;
using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.AggregatesModel.BookAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookService.Application.Features.BookImages.Commands.AddBookImageCommand
{
    public class AddBookImageCommandRequest : IRequest<IResponseModel>
    {
        public IFormFile Image { get; set; }
        public Guid BookId { get; set; }
    }
    public class AddBookImageCommandHandler : IRequestHandler<AddBookImageCommandRequest, IResponseModel>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IFileHelper _fileHelper;
        private readonly IMapper _mapper;

        public AddBookImageCommandHandler(IBookImageRepository bookImageRepository, IBookRepository bookRepository, IFileHelper fileHelper, IMapper mapper)
        {
            _bookImageRepository = bookImageRepository;
            _bookRepository = bookRepository;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(AddBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            var imagePath = _fileHelper.AddImageToProject(request.Image);
            var imageToAdd = _mapper.Map<BookImage>(request);
            imageToAdd.Id = Guid.NewGuid();
            imageToAdd.Path = imagePath;
            await _bookImageRepository.Add(imageToAdd);

            var bookToUpdate = await _bookRepository.GetById(imageToAdd.BookId);
            bookToUpdate.ImageIds.Add(imageToAdd.Id);
            await _bookRepository.Update(bookToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
