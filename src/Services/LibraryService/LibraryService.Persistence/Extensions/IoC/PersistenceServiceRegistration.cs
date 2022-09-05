using LibraryService.Application.Abstraction.Persistence.UserBookRepository;
using LibraryService.Persistence.EntityFramework.Repositories.UserBookRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IUserLibraryReadRepository, EfUserLibraryReadRepository>();
            services.AddSingleton<IUserLibraryWriteRepository, EfUserLibraryWriteRepository>();
        }
    }
}
