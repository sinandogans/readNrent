using MediatR;
using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;

namespace ReviewService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateBookReviewCommandRequest, UpdateBookReviewCommandResponse>
    {
        private readonly IBookReviewRepository _bookReviewRepository;

        public UpdateBookReviewCommandHandler(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<UpdateBookReviewCommandResponse> Handle(UpdateBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _bookReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            //if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            //{
            //    var book = await _bookRepository.GetByReviewId(request.Id);
            //    //book.Rating = (book.Rating * book.ReviewCount - reviewToUpdate.Rating + (double)request.Rating) / book.ReviewCount;
            //    await _bookRepository.Update(book);
            //}

            await _bookReviewRepository.Update(reviewToUpdate);

            return new UpdateBookReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
