using AutoMapper;
using LibraryService.Application.Abstraction.Persistence.UserBookRepository;
using LibraryService.Domain.Entities;
using MediatR;

namespace LibraryService.Application.Features.UserBooks.Commands.AddUserBookCommand
{
    public class AddLibraryBookCommandHandler : IRequestHandler<AddLibraryBookCommandRequest, AddLibraryBookCommandResponse>
    {
        private readonly IUserLibraryWriteRepository _userLibraryWriteRepository;
        private readonly IMapper _mapper;

        public AddLibraryBookCommandHandler(IUserLibraryWriteRepository userBookWriteRepository, IMapper mapper)
        {
            _userLibraryWriteRepository = userBookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddLibraryBookCommandResponse> Handle(AddLibraryBookCommandRequest request, CancellationToken cancellationToken)
        {
            var libraryBook = _mapper.Map<LibraryBook>(request);
            libraryBook.Id = Guid.NewGuid();
            await _userLibraryWriteRepository.AddLibraryBook(request.UserId, libraryBook);
            return _mapper.Map<AddLibraryBookCommandResponse>(libraryBook);
        }
    }
}
