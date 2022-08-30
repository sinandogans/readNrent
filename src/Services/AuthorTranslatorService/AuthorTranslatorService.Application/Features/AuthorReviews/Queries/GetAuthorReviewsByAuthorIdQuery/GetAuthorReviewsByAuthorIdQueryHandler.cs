using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByAuthorIdQuery
{
    public class GetAuthorReviewsByAuthorIdQueryHandler : IRequestHandler<GetAuthorReviewsByAuthorIdQueryRequest, List<GetAuthorReviewsByAuthorIdQueryResponse>>
    {
        private readonly IAuthorReviewReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAuthorReviewsByAuthorIdQueryHandler(IAuthorReviewReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorReviewsByAuthorIdQueryResponse>> Handle(GetAuthorReviewsByAuthorIdQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetList(r => r.AuthorId == request.AuthorId);
            List<GetAuthorReviewsByAuthorIdQueryResponse> responses = new();
            foreach (var review in reviews)
            {
                responses.Add(_mapper.Map<GetAuthorReviewsByAuthorIdQueryResponse>(review));
            }
            return responses;
        }
    }
}
