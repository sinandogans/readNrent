using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandHandler : IRequestHandler<AddAuthorReviewCommandRequest, AddAuthorReviewCommandResponse>
    {
        private readonly IAuthorReviewWriteRepository _writeRepository;
        private readonly IAuthorReviewReadRepository _readRepository;
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IMapper _mapper;
        public AddAuthorReviewCommandHandler(IAuthorReviewWriteRepository repository, IAuthorReviewReadRepository readRepository, IMapper mapper, IAuthorWriteRepository authorWriteRepository, IAuthorReadRepository authorReadRepository)
        {
            _writeRepository = repository;
            _readRepository = readRepository;
            _mapper = mapper;
            _authorWriteRepository = authorWriteRepository;
            _authorReadRepository = authorReadRepository;
        }
        public async Task<AddAuthorReviewCommandResponse> Handle(AddAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            //UserService'e UserId ile istek atıp firstname ve lastname'i alıp burdaki propertye eklenecek ve veritabanında tutulacak.
            string? username = null;
            var userReview = await _readRepository.Get(r => r.UserId == request.UserId);
            if (userReview == null)
            {
                // UserService'e istek at getir.
            }
            else
            {
                username = userReview.Username;
            }

            var reviewToAdd = _mapper.Map<AuthorReview>(request);
            reviewToAdd.Username = username;
            await _writeRepository.Add(reviewToAdd);

            var author = await _authorReadRepository.Get(a => a.Id == reviewToAdd.AuthorId);
            var ratingMultCount = author.Rating * author.ReviewCount;
            author.ReviewCount += 1;
            author.Rating = (ratingMultCount + reviewToAdd.Rating) / author.ReviewCount;
            await _authorWriteRepository.Update(author);

            var response = _mapper.Map<AddAuthorReviewCommandResponse>(reviewToAdd);
            return response;
        }
    }
}
