using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Middleware
{
    public class RequestExecutionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestExecutionMiddleware(RequestDelegate next, ILogger<Startup> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                watch.Stop();
                _logger.LogInformation("Request time: {Time}ms", watch.Elapsed.TotalMilliseconds);
            }
        }
    }
}
