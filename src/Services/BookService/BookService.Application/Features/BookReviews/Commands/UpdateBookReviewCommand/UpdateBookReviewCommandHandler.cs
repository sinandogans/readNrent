using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateBookReviewCommandRequest, UpdateBookReviewCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookReviewRepository _bookReviewRepository;

        public UpdateBookReviewCommandHandler(IBookRepository bookRepository, IBookReviewRepository bookReviewRepository)
        {
            _bookRepository = bookRepository;
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<UpdateBookReviewCommandResponse> Handle(UpdateBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _bookReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            {
                var book = await _bookRepository.GetByReviewId(request.Id);
                book.Rating = (book.Rating * book.ReviewCount - reviewToUpdate.Rating + (double)request.Rating) / book.ReviewCount;
                await _bookRepository.Update(book);
                reviewToUpdate.Rating = (double)request.Rating;
            }

            await _bookReviewRepository.Update(reviewToUpdate);

            return new UpdateBookReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
