using AutoMapper;
using LibraryService.Application.Abstraction.Persistence.UserLibraryRepository;
using LibraryService.Domain.Entities;
using MediatR;

namespace LibraryService.Application.Features.UserLibraries.Commands.AddLibraryBookCommand
{
    public class AddLibraryBookCommandHandler : IRequestHandler<AddLibraryBookCommandRequest, AddLibraryBookCommandResponse>
    {
        private readonly IUserLibraryRepository _userLibraryRepository;
        private readonly IMapper _mapper;

        public AddLibraryBookCommandHandler(IUserLibraryRepository userLibraryRepository, IMapper mapper)
        {
            _userLibraryRepository = userLibraryRepository;
            _mapper = mapper;
        }

        public async Task<AddLibraryBookCommandResponse> Handle(AddLibraryBookCommandRequest request, CancellationToken cancellationToken)
        {
            var libraryBook = _mapper.Map<LibraryBook>(request);
            libraryBook.Id = Guid.NewGuid();
            await _userLibraryRepository.AddLibraryBook(request.UserId, libraryBook);
            return _mapper.Map<AddLibraryBookCommandResponse>(libraryBook);
        }
    }
}
