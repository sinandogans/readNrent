using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Application.Features.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Languages.Commands.UpdateLanguageCommand
{
    public class UpdateLanguageCommandRequest : IRequest<UpdateLanguageCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommandRequest, UpdateLanguageCommandResponse>
    {
        private readonly ILanguageRepository _languageRepository;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<UpdateLanguageCommandResponse> Handle(UpdateLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var languageToUpdate = await _languageRepository.GetById(request.Id);
            languageToUpdate.Name = request.Name;
            await _languageRepository.Update(languageToUpdate);

            return new UpdateLanguageCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
    public class UpdateLanguageCommandResponse : Response
    {
    }
}
