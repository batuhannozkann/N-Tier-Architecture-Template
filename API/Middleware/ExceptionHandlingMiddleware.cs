using Newtonsoft.Json;
using Shared.Exceptions;
using System.Net;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            object response;
            switch (exception)
            {
                case NotFoundException notFoundEx:
                    context.Response.StatusCode = notFoundEx.ExceptionResponse.StatusCode;
                    response = new
                    {
                        message = notFoundEx.ExceptionResponse.Message,
                        exceptionDetail = exception.Message
                    };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new
                    {
                        message = "Internal server error. Please contact support or try again later.",
                        exceptionDetail = exception.Message
                    };
                    break;
            }

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
