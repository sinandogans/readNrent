using AutoMapper;
using Core.Utilities.Results;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandHandler : IRequestHandler<AddAuthorReviewCommandRequest, IResponseModel>
    {
        private readonly IAuthorReviewRepository _authorReviewRepository;
        private readonly IMapper _mapper;

        public AddAuthorReviewCommandHandler(IMapper mapper, IAuthorReviewRepository authorReviewRepository)
        {
            _mapper = mapper;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<IResponseModel> Handle(AddAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<AuthorReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;
            await _authorReviewRepository.Add(reviewToAdd);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
