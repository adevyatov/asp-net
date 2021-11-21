using System;
using System.Buffers.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
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

            try
            {
                var value = AuthenticationHeaderValue.Parse(authorization.ToString());

                if (value.Scheme != "Basic")
                {
                    throw new HttpStatusException(HttpStatusCode.BadRequest, "Only Basic authorization scheme is supported");
                }

                var expectedAuth = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("admin:admin"));
                var actualAuth = value.Parameter;

                if (expectedAuth != actualAuth)
                {
                    throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid authorization login or password");
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "Authorization header should has a value");
            }

            await _next.Invoke(context);
        }
    }
}
