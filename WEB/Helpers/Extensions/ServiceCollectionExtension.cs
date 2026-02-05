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
            services.AddScoped<IIgrejaService, IgrejaService>();
            services.AddScoped<IPastoresService, PastoresService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Repositories
            services.AddScoped<IDiaconatoRepository, DiaconatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<ISuperintendenteRegionalRepository, SuperintendenteRegionalRepository>();
            services.AddScoped<ISuperintendenteEstadualRepository, SuperintendenteEstadualRepository>();
            services.AddScoped<ISuperintendenteEstadualRepository, SuperintendenteEstadualRepository>();
            services.AddScoped<IIgrejaRepository, IgrejaRepository>();
            services.AddScoped<IPastoresRepository, PastoresRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}