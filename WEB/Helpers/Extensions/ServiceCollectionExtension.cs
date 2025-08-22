using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Services;
using WEB.Services.Interfaces;

namespace WEB.Helpers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IDiaconatoService, DiaconatoService>();

            //Repositories
            services.AddScoped<IDiaconatoRepository, DiaconatoRepository>();

            return services;
        }
    }
}
