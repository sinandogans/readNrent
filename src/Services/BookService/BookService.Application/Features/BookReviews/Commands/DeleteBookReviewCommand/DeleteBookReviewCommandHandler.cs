using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand
{
    public class DeleteBookReviewCommandHandler : IRequestHandler<DeleteBookReviewCommandRequest, DeleteBookReviewCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;

        public DeleteBookReviewCommandHandler(IBookRepository bookRepository, IMapper mapper, IBookReviewRepository bookReviewRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<DeleteBookReviewCommandResponse> Handle(DeleteBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _bookReviewRepository.GetById(request.Id);
            await _bookReviewRepository.Delete(request.Id);

            var book = await _bookRepository.GetByReviewId(request.Id);
            book.Rating = (book.Rating * book.ReviewCount - review.Rating) / (book.ReviewCount - 1);
            book.ReviewCount--;
            book.ReviewIds.Remove(review.Id);
            await _bookRepository.Update(book);

            return new DeleteBookReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
