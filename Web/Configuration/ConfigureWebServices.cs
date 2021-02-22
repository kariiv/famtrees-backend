using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamTrees.Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
