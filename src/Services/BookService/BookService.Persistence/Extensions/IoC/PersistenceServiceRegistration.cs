using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Persistence.EntityFramework.Repositories.BookRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IBookReadRepository, BookReadRepository>();
            services.AddSingleton<IBookWriteRepository, BookWriteRepository>();
        }
    }
}
