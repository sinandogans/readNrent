using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, AddAuthorCommandResponse>
    {
        private readonly IAuthorWriteRepository _repository;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAuthorWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddAuthorCommandResponse> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var authorToAdd = _mapper.Map<Author>(request);
            authorToAdd.Id = Guid.NewGuid();
            authorToAdd.Reviews = new List<AuthorReview>();

            await _repository.Add(authorToAdd);

            var response = _mapper.Map<AddAuthorCommandResponse>(authorToAdd);
            return response;
        }
    }
}
