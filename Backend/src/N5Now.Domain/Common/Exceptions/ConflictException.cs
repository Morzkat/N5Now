namespace N5Now.Domain.Common.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException() : base(HttpStatusCodes.NotFound)
        {
        }

        public ConflictException(string message) : base(HttpStatusCodes.NotFound, message)
        {
        }
    }
}
