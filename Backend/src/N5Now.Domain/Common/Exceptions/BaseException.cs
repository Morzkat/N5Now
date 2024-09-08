namespace N5Now.Domain.Common.Exceptions
{
    public class BaseException : Exception
    {
        public HttpStatusCodes StatusCode { get; }

        public BaseException(HttpStatusCodes statusCode)
        {
            StatusCode = statusCode;
        }

        public BaseException(HttpStatusCodes statusCode, string message)
        : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
