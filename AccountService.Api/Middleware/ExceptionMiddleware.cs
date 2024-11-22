using AccountMS.Exceptions;
using System.Net;
using System.Text.Json;

namespace AccountService.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = (int)HttpStatusCode.InternalServerError;
        var result = new
        {
            Message = "Error en el servidor, vuelva a intentar"
        };

        if (exception is AccountException accountException)
        {
            statusCode = (int)HttpStatusCode.BadRequest;
            result = new
            {
                Message = accountException.Message
            };
        }

        context.Response.StatusCode = statusCode;

        // Serialize the response
        return context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
