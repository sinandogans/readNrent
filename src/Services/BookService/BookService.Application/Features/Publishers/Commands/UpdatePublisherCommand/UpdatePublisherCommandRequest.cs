using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Publishers.Commands.UpdatePublisherCommand
{
    public class UpdatePublisherCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, IResponseModel>
    {
        private readonly IPublisherRepository _publisherRepository;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IResponseModel> Handle(UpdatePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var publisherToUpdate = await _publisherRepository.GetById(request.Id);
            publisherToUpdate.Name = request.Name;
            await _publisherRepository.Update(publisherToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
