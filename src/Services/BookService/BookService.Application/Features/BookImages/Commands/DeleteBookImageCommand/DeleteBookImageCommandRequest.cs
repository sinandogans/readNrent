using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookImages.Commands.DeleteBookImageCommand
{
    public class DeleteBookImageCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
    }
    public class DeleteBookImageCommandHandler : IRequestHandler<DeleteBookImageCommandRequest, IResponseModel>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteBookImageCommandHandler(IBookImageRepository bookImageRepository, IBookRepository bookRepository)
        {
            _bookImageRepository = bookImageRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IResponseModel> Handle(DeleteBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _bookImageRepository.Delete(request.Id);

            var bookToUpdate = await _bookRepository.GetByImageId(request.Id);
            bookToUpdate.ImageIds.Remove(request.Id);
            await _bookRepository.Update(bookToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
