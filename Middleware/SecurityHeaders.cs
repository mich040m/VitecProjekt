using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecProjekt.Middleware
{
    public class SecurityHeaders
    {

        private readonly RequestDelegate _next;

        public SecurityHeaders(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Feature-Policy", "camera 'none'");
            await _next(context);
        }



    }

    public static class IApplicationBuilderExtensions
    {
        public static void UseSecurityHeaders(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecurityHeaders>();
        }
    }
}
