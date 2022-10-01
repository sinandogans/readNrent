using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandHandler : IRequestHandler<DeleteAuthorReviewCommandRequest, DeleteAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorReviewRepository _authorReviewRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorReviewCommandHandler(IAuthorRepository authorRepository, IMapper mapper, IAuthorReviewRepository authorReviewRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<DeleteAuthorReviewCommandResponse> Handle(DeleteAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _authorReviewRepository.GetById(request.Id);
            await _authorReviewRepository.Delete(request.Id);

            var author = await _authorRepository.GetByReviewId(request.Id);
            author.Rating = (author.Rating * author.ReviewCount - review.Rating) / (author.ReviewCount - 1);
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
