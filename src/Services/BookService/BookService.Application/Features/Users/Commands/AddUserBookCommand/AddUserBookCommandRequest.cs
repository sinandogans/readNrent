using AutoMapper;
using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using BookService.Domain.Enums;
using MediatR;

namespace BookService.Application.Features.Users.Commands.AddUserBookCommand
{
    public class AddUserBookCommandRequest : IRequest<AddUserBookCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BeginDate { get; set; } = default;
        public DateTime EndDate { get; set; } = default;
        public Status Status { get; set; } = 0;
        public int Rating { get; set; }
    }
    public class AddUserBookCommandHandler : IRequestHandler<AddUserBookCommandRequest, AddUserBookCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserBookCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AddUserBookCommandResponse> Handle(AddUserBookCommandRequest request, CancellationToken cancellationToken)
        {
            var userBookToAdd = _mapper.Map<UserBook>(request);
            var userToUpdate = await _userRepository.GetById(request.UserId);
            userToUpdate.UserBooks.Add(userBookToAdd);
            await _userRepository.Update(userToUpdate);

            return new AddUserBookCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
    public class AddUserBookCommandResponse : Response
    {
    }
}
