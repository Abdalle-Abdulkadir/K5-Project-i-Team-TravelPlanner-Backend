using System.Text.Json;
using TravelPlanner.Api.Exceptions;

namespace TravelPlanner.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
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
            context.Response.ContentType = "application/json";

            if (ex is AppException appException)
            {
                context.Response.StatusCode = appException.StatusCode;
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            var response = new
            {
                Message = ex is AppException ? ex.Message : "An unexpected error occurred.",
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }

    }
}


