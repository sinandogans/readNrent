using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Application.Abstraction.Persistence.PublishRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Publishes.Commands.AddPublishCommand
{
    public class AddPublishCommandRequest : IRequest<IResponseModel>
    {
        public Guid PublisherId { get; set; }
        public Guid BookId { get; set; }
        public Guid LanguageId { get; set; }
    }
    public class AddPublishCommandHandler : IRequestHandler<AddPublishCommandRequest, IResponseModel>
    {
        private readonly IPublishRepository _publishRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public AddPublishCommandHandler(IPublishRepository publishRepository, IMapper mapper, IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            _publishRepository = publishRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<IResponseModel> Handle(AddPublishCommandRequest request, CancellationToken cancellationToken)
        {
            var publishToAdd = _mapper.Map<Publish>(request);
            publishToAdd.Id = Guid.NewGuid();
            publishToAdd.PublishDate = DateTime.Now;
            await _publishRepository.Add(publishToAdd);

            var book = await _bookRepository.GetById(publishToAdd.BookId);
            book.PublishIds.Add(publishToAdd.Id);
            await _bookRepository.Update(book);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
