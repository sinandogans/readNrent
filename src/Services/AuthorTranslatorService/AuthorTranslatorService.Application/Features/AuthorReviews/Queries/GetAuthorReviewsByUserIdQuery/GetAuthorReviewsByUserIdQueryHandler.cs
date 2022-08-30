using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByUserIdQuery
{
    public class GetAuthorReviewsByUserIdQueryHandler : IRequestHandler<GetAuthorReviewsByUserIdQueryRequest, List<GetAuthorReviewsByUserIdQueryResponse>>
    {
        private readonly IAuthorReviewReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAuthorReviewsByUserIdQueryHandler(IAuthorReviewReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorReviewsByUserIdQueryResponse>> Handle(GetAuthorReviewsByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetList(r => r.UserId == request.UserId);
            List<GetAuthorReviewsByUserIdQueryResponse> responses = new();
            foreach (var review in reviews)
            {
                responses.Add(_mapper.Map<GetAuthorReviewsByUserIdQueryResponse>(review));
            }
            return responses;
        }
    }
}
