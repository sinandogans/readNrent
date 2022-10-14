using AutoMapper;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;

namespace ReviewService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandHandler : IRequestHandler<DeleteAuthorReviewCommandRequest, DeleteAuthorReviewCommandResponse>
    {
        private readonly IAuthorReviewRepository _authorReviewRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorReviewCommandHandler(IMapper mapper, IAuthorReviewRepository authorReviewRepository)
        {
            _mapper = mapper;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<DeleteAuthorReviewCommandResponse> Handle(DeleteAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _authorReviewRepository.GetById(request.Id);
            await _authorReviewRepository.Delete(request.Id);

            return new DeleteAuthorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
