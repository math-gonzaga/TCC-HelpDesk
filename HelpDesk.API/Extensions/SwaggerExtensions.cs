using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace HelpDesk.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void SwaggerConfigurarion(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "HelpDesk.API", 
                    Version = "v1",
                    Description = "API Help Desk"
                });
            });
        }
    }
}