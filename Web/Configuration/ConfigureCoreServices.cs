
using FamTrees.Core.Interfaces;
using FamTrees.Core.Services;
using FamTrees.Infrastructure.Data;
using FamTrees.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamTrees.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<IFamilyTreeService, FamilyTreeService>();
            services.AddScoped<IFamilyService, FamilyService>();


            return services;
        }
    }
}
