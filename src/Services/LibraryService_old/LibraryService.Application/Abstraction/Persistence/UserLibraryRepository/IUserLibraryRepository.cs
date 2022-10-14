using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.UserLibraryRepository
{
    public interface IUserLibraryRepository : IBaseRepository<UserLibrary>
    {
        public Task AddLibraryBook(Guid userId, LibraryBook libraryBook);
    }
}
