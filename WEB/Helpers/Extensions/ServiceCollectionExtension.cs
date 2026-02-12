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
            services.AddScoped<IRegiaoService, RegiaoService>();
            services.AddScoped<ISuperintendenteRegionalService, SuperintendenteRegionalService>();
            services.AddScoped<ISuperintendenteEstadualService, SuperintendenteEstadualService>();
            services.AddScoped<IIgrejaService, IgrejaService>();
            services.AddScoped<IPastoresService, PastoresService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICriancaService, CriancaService>();
            services.AddScoped<IHomensService, HomensService>();
            services.AddScoped<IMulheresService, MulheresService>();
            services.AddScoped<IJovemAdolescenteService, JovemAdolescenteService>();
            services.AddScoped<ILouvorService, LouvorService>();
            services.AddScoped<IMidiaService, MidiaService>();
            services.AddScoped<ITeatroService, TeatroService>();

            //Repositories
            services.AddScoped<IDiaconatoRepository, DiaconatoRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<ISuperintendenteRegionalRepository, SuperintendenteRegionalRepository>();
            services.AddScoped<ISuperintendenteEstadualRepository, SuperintendenteEstadualRepository>();
            services.AddScoped<ISuperintendenteEstadualRepository, SuperintendenteEstadualRepository>();
            services.AddScoped<IIgrejaRepository, IgrejaRepository>();
            services.AddScoped<IPastoresRepository, PastoresRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICriancaRepository, CriancaRepository>();
            services.AddScoped<IHomensRepository, HomensRepository>();
            services.AddScoped<IMulheresRepository, MulheresRepository>();
            services.AddScoped<IJovemAdolescenteRepository, JovemAdolescenteRepository>();
            services.AddScoped<ILouvorRepository, LouvorRepository>();
            services.AddScoped<IMidiaRepository, MidiaRepository>();
            services.AddScoped<ITeatroRepository, TeatroRepository>();

            return services;
        }
    }
}