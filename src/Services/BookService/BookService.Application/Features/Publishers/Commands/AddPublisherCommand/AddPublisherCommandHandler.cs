using AutoMapper;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Publishers.Commands.AddPublisherCommand
{
    public class AddPublisherCommandHandler : IRequestHandler<AddPublisherCommandRequest, AddPublisherCommandResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public AddPublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<AddPublisherCommandResponse> Handle(AddPublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var publisherToAdd = _mapper.Map<Publisher>(request);
            publisherToAdd.Id = Guid.NewGuid();
            await _publisherRepository.Add(publisherToAdd);

            return new AddPublisherCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
