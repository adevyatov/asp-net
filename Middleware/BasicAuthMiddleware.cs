using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi.Exceptions;

namespace WebApi.Middleware
{
    /// <summary>
    ///     2.2.1 - Middleware, который запрещает делать запрос без хедера “Authorization” со значением “Basic admin:admin”
    /// </summary>
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authorization = context.Request.Headers["Authorization"];

            if (authorization.Count == 0)
            {
                throw new HttpStatusException(HttpStatusCode.Unauthorized, "You should pass Authorization header");
            }

            var credentials = authorization.ToString().Split(':');

            try
            {
                var username = credentials[0] ?? "";
                var password = credentials[1] ?? "";

                if (username != "admin" || password != "admin")
                {
                    throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid authorization login or password");
                }
            }
            catch (Exception)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Cannot parse authorization header");
            }

            await _next.Invoke(context);
        }
    }
}
