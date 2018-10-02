namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base("The Request was malformed or contains unsupported elements.")
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}