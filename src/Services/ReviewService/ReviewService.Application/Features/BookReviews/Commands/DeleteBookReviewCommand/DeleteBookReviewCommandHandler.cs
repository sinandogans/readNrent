using AutoMapper;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;

namespace ReviewService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand
{
    public class DeleteBookReviewCommandHandler : IRequestHandler<DeleteBookReviewCommandRequest, DeleteBookReviewCommandResponse>
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;

        public DeleteBookReviewCommandHandler(IMapper mapper, IBookReviewRepository bookReviewRepository)
        {
            _mapper = mapper;
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<DeleteBookReviewCommandResponse> Handle(DeleteBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = await _bookReviewRepository.GetById(request.Id);
            await _bookReviewRepository.Delete(request.Id);

            return new DeleteBookReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
