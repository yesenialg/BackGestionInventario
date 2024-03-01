namespace Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string exceptionMessage) : base(exceptionMessage)
        { }
    }
}
