using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandHandler : IRequestHandler<AddAuthorReviewCommandRequest, AddAuthorReviewCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorReviewRepository _authorReviewRepository;
        private readonly IMapper _mapper;

        public AddAuthorReviewCommandHandler(IAuthorRepository authorRepository, IMapper mapper, IAuthorReviewRepository authorReviewRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<AddAuthorReviewCommandResponse> Handle(AddAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<AuthorReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;
            await _authorReviewRepository.Add(reviewToAdd);

            var author = await _authorRepository.GetById(reviewToAdd.AuthorId);
            author.ReviewIds.Add(reviewToAdd.Id);
            author.Rating = ((author.Rating * author.ReviewCount) + reviewToAdd.Rating) / (author.ReviewCount + 1);
            author.ReviewCount++;
            await _authorRepository.Update(author);

            return new AddAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
