using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Persistence.MongoDbDriver.Contexts;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.AuthorRepository;
using AuthorTranslatorService.Persistence.MongoDbDriver.Repositories.TranslatorRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorTranslatorService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<IAuthorRepository, MDBAuthorRepository>();
            services.AddSingleton<ITranslatorRepository, MDBTranslatorRepository>();
        }
    }
}
