using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommandRequest, AddBookReviewCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;

        public AddBookReviewCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddBookReviewCommandResponse> Handle(AddBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<BookReview>(request);
            review.Id = Guid.NewGuid();

            await _bookWriteRepository.AddBookReview(review);

            var response = _mapper.Map<AddBookReviewCommandResponse>(review);
            return response;
        }
    }
}
