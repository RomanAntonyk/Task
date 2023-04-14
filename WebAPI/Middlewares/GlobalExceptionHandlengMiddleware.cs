using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class GlobalExceptionHandlengMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server erroe",
                    Detail = e.Message
                };

                string json = JsonSerializer.Serialize(problem);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";
            }
        }
    }
}
