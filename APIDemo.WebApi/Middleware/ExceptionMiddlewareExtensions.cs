using Serilog;
using Microsoft.AspNetCore.Builder;

namespace GlobalErrorHandling.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}