using IdentityService.Application.Abstraction.Persistence.RoleClaimRepository;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Persistence.EntityFramework.Repositories.RoleClaimRepository;
using IdentityService.Persistence.EntityFramework.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, EFUserRepository>();

            services.AddSingleton<IRoleClaimRepository, EFRoleClaimRepository>();
        }
    }
}
