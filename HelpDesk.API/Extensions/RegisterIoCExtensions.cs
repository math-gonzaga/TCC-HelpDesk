using HelpDesk.Application.Applications;
using HelpDesk.Application.Interfaces;
using HelpDesk.Application.Interfaces.Security;
using HelpDesk.Application.Security;
using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Services;
using HelpDesk.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.API.Extensions
{
    public static class RegisterIoCExtensions
    {
        public static void RegisterIoC(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IChamadoApplication, ChamadoApplication>();
            services.AddScoped<IChamadoService, ChamadoService>();
            services.AddScoped<IChamadoRepository, ChamadoRepository>();

            services.AddScoped<ITipoUsuarioApplication, TipoUsuarioApplication>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();

            services.AddScoped<ISegurancaService, SegurancaService>();
            services.AddScoped<ITokenManager, TokenManager>();

        }
    }
}