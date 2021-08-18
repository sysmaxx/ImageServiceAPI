using ImageServiceApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ImageServiceApi.Configurations
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
