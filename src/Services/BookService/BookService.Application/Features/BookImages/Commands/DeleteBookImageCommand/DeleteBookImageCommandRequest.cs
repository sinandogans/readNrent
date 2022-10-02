using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Features.ResponseModel;
using MediatR;

namespace BookService.Application.Features.BookImages.Commands.DeleteBookImageCommand
{
    public class DeleteBookImageCommandRequest : IRequest<DeleteBookImageCommandResponse>
    {
        public Guid Id { get; set; }
    }
    public class DeleteBookImageCommandHandler : IRequestHandler<DeleteBookImageCommandRequest, DeleteBookImageCommandResponse>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteBookImageCommandHandler(IBookImageRepository bookImageRepository, IBookRepository bookRepository)
        {
            _bookImageRepository = bookImageRepository;
            _bookRepository = bookRepository;
        }

        public async Task<DeleteBookImageCommandResponse> Handle(DeleteBookImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _bookImageRepository.Delete(request.Id);

            var bookToUpdate = await _bookRepository.GetByImageId(request.Id);
            bookToUpdate.ImageIds.Remove(request.Id);
            await _bookRepository.Update(bookToUpdate);

            return new DeleteBookImageCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
    public class DeleteBookImageCommandResponse : Response
    {
    }
}
