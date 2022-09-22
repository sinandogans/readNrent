using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorTranslatorService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, EFAuthorRepository>();

            services.AddScoped<ITranslatorRepository, EFTranslatorRepository>();
        }
    }
}
