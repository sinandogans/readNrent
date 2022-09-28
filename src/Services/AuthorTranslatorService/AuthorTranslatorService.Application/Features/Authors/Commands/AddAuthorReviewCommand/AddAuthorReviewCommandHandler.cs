using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandHandler : IRequestHandler<AddAuthorReviewCommandRequest, AddAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AddAuthorReviewCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AddAuthorReviewCommandResponse> Handle(AddAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<AuthorReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;

            await _authorRepository.AddReview(reviewToAdd);

            var response = _mapper.Map<AddAuthorReviewCommandResponse>(reviewToAdd);
            return response;
        }
    }
}
