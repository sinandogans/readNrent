using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorRepository;
using AuthorTranslatorService.Persistence.EntityFramework.Repositories.TranslatorReviewRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorTranslatorService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            services.AddScoped<IAuthorReviewReadRepository, AuthorReviewReadRepository>();
            services.AddScoped<IAuthorReviewWriteRepository, AuthorReviewWriteRepository>();

            services.AddScoped<ITranslatorReadRepository, TranslatorReadRepository>();
            services.AddScoped<ITranslatorWriteRepository, TranslatorWriteRepository>();

            services.AddScoped<ITranslatorReviewReadRepository, TranslatorReviewReadRepository>();
            services.AddScoped<ITranslatorReviewWriteRepository, TranslatorReviewWriteRepository>();
        }
    }
}
