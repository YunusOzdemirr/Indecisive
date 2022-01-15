using System.Net;
using Shared.Utilities.Exceptions;
using Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;

namespace Indecisive.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                switch (ex)
                {
                    case NotFoundException error1:
                        await NotFoundException(context, error1);
                        break;
                    case NotFoundExceptions error2:
                        await NotFoundExceptions(context, error2);
                        break;
                    case ExistArgumentException error3:
                        await ExistArgumentException(context, error3);
                        break;
                    case ValidationErrorsExceptions error4:
                        await ValidationErrorsExceptions(context, error4);
                        break;
                    case ValidationErrorException error5:
                        await ValidationErrorException(context, error5);
                        break;
                    default:
                        await GeneralException(context, ex);
                        break;
                }
            }
        }

        private async Task GeneralException(HttpContext context, Exception ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Detail = ex.StackTrace,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
        private async Task NotFoundException(HttpContext context, NotFoundException ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Error = ex.ValidationError,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
        private async Task NotFoundExceptions(HttpContext context, NotFoundExceptions ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Error = ex.Errors,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
        private async Task ExistArgumentException(HttpContext context, ExistArgumentException ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Error = ex.ValidationError,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
        private async Task ValidationErrorException(HttpContext context, ValidationErrorException ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Error = ex.ValidationErrors,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
        private async Task ValidationErrorsExceptions(HttpContext context, ValidationErrorsExceptions ex)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = ex.Message,
                Error = ex.ValidationErrors,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

        }
    }
}