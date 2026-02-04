using WEB.Data.Repositories;
using WEB.Data.Repositories.Interfaces;
using WEB.Models.Entities;
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
            services.AddScoped<IRegiaoService, RegiaoService>();
            services.AddScoped<ISuperintendenteRegionalService, SuperintendenteRegionalService>();
            services.AddScoped<ISuperintendenteEstadualService, SuperintendenteEstadualService>();

            services.AddScoped<IGerenciamentoService, GerenciamentoService>();

            //Repositories
            services.AddScoped<IDiaconatoRepository, DiaconatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<ISuperintendenteRegionalRepository, SuperintendenteRegionalRepository>();
            services.AddScoped<ISuperintendenteEstadualRepository, SuperintendenteEstadualRepository>();

            services.AddScoped<IGerenciamentoRepository, GerenciamentoRepository>();

            return services;
        }
    }
}
