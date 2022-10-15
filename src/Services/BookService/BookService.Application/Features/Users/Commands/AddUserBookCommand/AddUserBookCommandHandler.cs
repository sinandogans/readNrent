using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Users.Commands.AddUserBookCommand
{
    public class AddUserBookCommandHandler : IRequestHandler<AddUserBookCommandRequest, IResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserBookCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(AddUserBookCommandRequest request, CancellationToken cancellationToken)
        {
            var userBookToAdd = _mapper.Map<UserBook>(request);
            var userToUpdate = await _userRepository.GetById(request.UserId);
            userToUpdate.UserBooks.Add(userBookToAdd);
            userToUpdate.BookCount++;
            await _userRepository.Update(userToUpdate);

            //var bookToUpdate = await _bookRepository.GetById(request.BookId);
            //bookToUpdate.Rating = (bookToUpdate.Rating * bookToUpdate.RatingCount + userBookToAdd.Rating) / (bookToUpdate.RatingCount + 1);
            //bookToUpdate.RatingCount++;

            //await _bookRepository.Update(bookToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
