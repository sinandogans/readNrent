using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandHandler : IRequestHandler<DeleteAuthorReviewCommandRequest, IResponseModel>
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

        public async Task<IResponseModel> Handle(DeleteAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _authorReviewRepository.GetById(request.Id);
            await _authorReviewRepository.Delete(request.Id);

            var author = await _authorRepository.GetByReviewId(request.Id);
            author.ReviewCount--;
            author.ReviewIds.Remove(review.Id);
            await _authorRepository.Update(author);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
