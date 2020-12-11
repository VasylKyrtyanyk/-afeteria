using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Сafeteria.Middlewares.HelperClasses;
using Сafeteria.Services.Common.Exeptions;

namespace Сafeteria.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string stackTrace = String.Empty;

            var exceptionType = ex.GetType();
            if (exceptionType == typeof(ArgumentNullException) ||
                exceptionType == typeof(ArgumentException))
            {
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(AuthorizationFailedExeption))
            {
                status = HttpStatusCode.Unauthorized;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                if (_env.IsEnvironment("Development"))
                {
                    stackTrace = ex.StackTrace;
                }
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StackTrace = stackTrace,
                Message = ex.Message
            }.ToString());
        }
    }
}