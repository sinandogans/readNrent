using LibraryService.Application.Abstraction.Persistence.BookRepository;
using LibraryService.Application.Abstraction.Persistence.UserLibraryRepository;
using LibraryService.Persistence.EntityFramework.Repositories.BookRepository;
using LibraryService.Persistence.EntityFramework.Repositories.UserLibraryRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IUserLibraryRepository, EFUserLibraryRepository>();
            services.AddSingleton<IBookRepository, EFBookRepository>();
        }
    }
}
