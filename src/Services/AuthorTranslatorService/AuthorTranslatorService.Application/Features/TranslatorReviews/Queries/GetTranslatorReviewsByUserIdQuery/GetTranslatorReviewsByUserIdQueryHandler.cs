using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByUserIdQuery
{
    public class GetTranslatorReviewsByUserIdQueryHandler : IRequestHandler<GetTranslatorReviewsByUserIdQueryRequest, List<GetTranslatorReviewsByUserIdQueryResponse>>
    {
        private readonly ITranslatorReviewReadRepository _repository;
        private readonly IMapper _mapper;

        public GetTranslatorReviewsByUserIdQueryHandler(ITranslatorReviewReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTranslatorReviewsByUserIdQueryResponse>> Handle(GetTranslatorReviewsByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetList(r => r.UserId == request.UserId);
            List<GetTranslatorReviewsByUserIdQueryResponse> response = new();
            foreach (var review in reviews)
            {
                response.Add(_mapper.Map<GetTranslatorReviewsByUserIdQueryResponse>(review));
            }
            return response;
        }
    }
}
