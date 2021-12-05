using System.Net;

namespace WebApi.Exceptions
{
    public class HttpConstraintException : HttpStatusException
    {
        public HttpConstraintException(string message) : base(HttpStatusCode.UnprocessableEntity, message)
        {
        }
    }
}
