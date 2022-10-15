using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Languages.Commands.AddLanguageCommand
{
    public class AddLanguageCommandRequest : IRequest<IResponseModel>
    {
        public string Name { get; set; }
    }
}
