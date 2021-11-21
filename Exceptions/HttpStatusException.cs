using System;
using System.Net;

namespace WebApi.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode Status { get; }

        public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}
