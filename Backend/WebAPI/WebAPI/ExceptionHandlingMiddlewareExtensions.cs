using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using WebApi.DTOs;

namespace WebApi
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
        public class ExceptionHandlingMiddleware
        {
            private readonly RequestDelegate _next;
            
            public ExceptionHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (InvalidDataException)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    
                    await context.Response.WriteAsync("Invalid data");
                }
            }
        }
    }
}
