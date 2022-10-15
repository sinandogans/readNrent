using IdentityService.Application.Abstraction.Application.Security;
using IdentityService.Application.Utilities.Security.JWT;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IdentityService.Application.Extensions.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
