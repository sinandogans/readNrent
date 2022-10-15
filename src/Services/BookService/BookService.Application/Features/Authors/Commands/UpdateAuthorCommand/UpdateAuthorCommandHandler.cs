using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, IResponseModel>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var authorToUpdate = await _authorRepository.GetById(request.Id);
            if (request.Firstname != null)
                authorToUpdate.Firstname = request.Firstname;
            if (request.Lastname != null)
                authorToUpdate.Lastname = request.Lastname;

            await _authorRepository.Update(authorToUpdate);
            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
