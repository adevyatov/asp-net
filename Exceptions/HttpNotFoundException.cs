using System.Net;

namespace WebApi.Exceptions
{
    public class HttpNotFoundException : HttpStatusException
    {
        public HttpNotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
