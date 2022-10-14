using AutoMapper;
using Core.Utilities.Results;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;

namespace ReviewService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandHandler : IRequestHandler<DeleteAuthorReviewCommandRequest, IResponseModel>
    {
        private readonly IAuthorReviewRepository _authorReviewRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorReviewCommandHandler(IMapper mapper, IAuthorReviewRepository authorReviewRepository)
        {
            _mapper = mapper;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<IResponseModel> Handle(DeleteAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _authorReviewRepository.GetById(request.Id);
            await _authorReviewRepository.Delete(request.Id);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
