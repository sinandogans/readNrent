using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Persistence.EntityFramework.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IUserReadRepository, EfUserReadRepository>();
            services.AddSingleton<IUserWriteRepository, EfUserWriteRepository>();
        }
    }
}
