using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.AddAuthorCommand
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, IResponseModel>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var authorToAdd = _mapper.Map<Author>(request);
            authorToAdd.Id = Guid.NewGuid();

            await _authorRepository.Add(authorToAdd);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}