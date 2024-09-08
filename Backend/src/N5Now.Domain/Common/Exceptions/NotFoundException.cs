namespace N5Now.Domain.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base(HttpStatusCodes.NotFound)
        {
        }

        public NotFoundException(string message) : base(HttpStatusCodes.NotFound, message)
        {
        }
    }
}
