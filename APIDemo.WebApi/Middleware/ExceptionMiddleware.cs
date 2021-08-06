using GlobalErrorHandling.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace GlobalErrorHandling.Extensions
{
    /// <summary>
    /// Clase para trabajar las excepciones del middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogCritical(ex, "Ocurrio un error Trace {trace} ", Encrit());
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Error de Procesamiento : .",
                Trace = Encrit()
            }.ToString());
        }

        public static string Encrit()
        {
            string _trace;
            _trace = Trace.Instance.generaTrace("ExceptionMiddleware", "HandleException");
            return _trace;
        }
    }
}