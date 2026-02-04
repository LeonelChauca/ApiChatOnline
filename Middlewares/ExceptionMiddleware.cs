using System;
using ApiChatOnline.config.HandleErrors;
using ApiChatOnline.config.Response;

namespace ApiChatOnline.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var mensaje = "Ocurrió un error inesperado.";
            var statusCode = 500;
            string[]? errores = null;

            if (ex is HandleErrorBase handleError)
            {
                mensaje = handleError.Message;
                statusCode = handleError.Status;
            }
            else if (ex is MongoDB.Driver.MongoException)
            {
                mensaje = "Error de base de datos.";
                statusCode = 500;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var respuesta = new ApiResponseFail<object>(mensaje, errores);
            await context.Response.WriteAsJsonAsync(respuesta);
        }
    }
}
