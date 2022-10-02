using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand
{
    public class UpdateBookReviewCommandHandler : IRequestHandler<UpdateAuthorReviewCommandRequest, UpdateAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _bookRepository;
        private readonly IAuthorReviewRepository _bookReviewRepository;

        public UpdateBookReviewCommandHandler(IAuthorRepository authorRepository, IAuthorReviewRepository authorReviewRepository)
        {
            _bookRepository = authorRepository;
            _bookReviewRepository = authorReviewRepository;
        }

        public async Task<UpdateAuthorReviewCommandResponse> Handle(UpdateAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _bookReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            {
                var author = await _bookRepository.GetByReviewId(request.Id);
                author.Rating = (author.Rating * author.ReviewCount - reviewToUpdate.Rating + (double)request.Rating) / author.ReviewCount;
                await _bookRepository.Update(author);
                reviewToUpdate.Rating = (double)request.Rating;
            }

            await _bookReviewRepository.Update(reviewToUpdate);

            return new UpdateAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
