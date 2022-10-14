using AutoMapper;
using Core.Utilities.Results;
using MediatR;
using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Features.BookReviews.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommandRequest, IResponseModel>
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;

        public AddBookReviewCommandHandler(IMapper mapper, IBookReviewRepository bookReviewRepository)
        {
            _mapper = mapper;
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<IResponseModel> Handle(AddBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<BookReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;
            await _bookReviewRepository.Add(reviewToAdd);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
