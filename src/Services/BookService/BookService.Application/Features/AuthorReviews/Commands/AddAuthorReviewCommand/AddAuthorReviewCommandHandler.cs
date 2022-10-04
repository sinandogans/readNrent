using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
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
            author.Feature.Rating = (author.Feature.Rating * author.Feature.ReviewCount + reviewToAdd.Rating) / (author.Feature.ReviewCount + 1);
            author.Feature.ReviewCount++;
            await _authorRepository.Update(author);

            return new AddAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
