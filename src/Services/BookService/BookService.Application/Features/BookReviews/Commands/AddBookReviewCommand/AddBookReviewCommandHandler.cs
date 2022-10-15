using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.BookReviews.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommandRequest, IResponseModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;

        public AddBookReviewCommandHandler(IBookRepository bookRepository, IMapper mapper, IBookReviewRepository bookReviewRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<IResponseModel> Handle(AddBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<BookReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;
            await _bookReviewRepository.Add(reviewToAdd);

            var book = await _bookRepository.GetById(reviewToAdd.BookId);
            book.ReviewIds.Add(reviewToAdd.Id);
            //book.Rating = (book.Rating * book.ReviewCount + reviewToAdd.Rating) / (book.ReviewCount + 1);
            book.ReviewCount++;
            await _bookRepository.Update(book);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
