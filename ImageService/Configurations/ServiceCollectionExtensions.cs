using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ImageServiceApi.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ImageService", Version = "v1" });
            });
        }
    }
}
