using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorReviewCommand
{
    public class UpdateAuthorReviewCommandHandler : IRequestHandler<UpdateAuthorReviewCommandRequest, UpdateAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorReviewRepository _authorReviewRepository;

        public UpdateAuthorReviewCommandHandler(IAuthorRepository authorRepository, IAuthorReviewRepository authorReviewRepository)
        {
            _authorRepository = authorRepository;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<UpdateAuthorReviewCommandResponse> Handle(UpdateAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _authorReviewRepository.GetById(request.Id);
            if (request.Comment != null && request.Comment != reviewToUpdate.Comment)
            {
                reviewToUpdate.Comment = request.Comment;
            }
            if (request.Rating != null && request.Rating != reviewToUpdate.Rating)
            {
                var author = await _authorRepository.GetByReviewId(request.Id);
                author.Rating = ((author.Rating * author.ReviewCount) - reviewToUpdate.Rating + (double)request.Rating) / (author.ReviewCount);
                await _authorRepository.Update(author);
                reviewToUpdate.Rating = (double)request.Rating;
            }

            await _authorReviewRepository.Update(reviewToUpdate);

            return new UpdateAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
