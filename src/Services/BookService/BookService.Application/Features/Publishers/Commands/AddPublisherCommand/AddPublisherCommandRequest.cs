using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Publishers.Commands.AddPublisherCommand
{
    public class AddPublisherCommandRequest : IRequest<IResponseModel>
    {
        public string Name { get; set; }
    }
}
