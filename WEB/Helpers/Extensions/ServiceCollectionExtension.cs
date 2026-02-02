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
            services.AddScoped<IGerenciamentoService, GerenciamentoService>();

            //Repositories
            services.AddScoped<IDiaconatoRepository, DiaconatoRepository>();
            services.AddScoped<IGerenciamentoRepository, GerenciamentoRepository>();

            return services;
        }
    }
}
