using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandHandler : IRequestHandler<DeleteAuthorReviewCommandRequest, DeleteAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorReviewCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<DeleteAuthorReviewCommandResponse> Handle(DeleteAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _authorRepository.GetReviewById(request.Id);
            await _authorRepository.DeleteReview(request.Id);

            var author = await _authorRepository.GetByReviewId(request.Id);
            author.Rating = ((author.Rating * author.ReviewCount) - review.Rating) / (author.ReviewCount - 1);
            author.ReviewCount--;
            author.ReviewIds.Remove(review.Id);
            await _authorRepository.Update(author);

            return new DeleteAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
