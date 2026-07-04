using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Api.Middleware
{
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
                await HandleExceptionAsync(context,ex);
            }

        }
        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;
            switch (ex)
            {
                case ValidationException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case EntityNotFoundException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case AuthenticationException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocurrió un error inesperado al ejecutar la solicitud";
                    break;
            }
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(result);
        }
    }
}
