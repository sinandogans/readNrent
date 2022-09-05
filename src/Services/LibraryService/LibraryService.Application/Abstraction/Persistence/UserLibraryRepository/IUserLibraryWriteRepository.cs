using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.UserBookRepository
{
    public interface IUserLibraryWriteRepository : IBaseWriteRepository<UserLibrary>
    {
        public Task AddLibraryBook(Guid userId, LibraryBook libraryBook);

    }
}
