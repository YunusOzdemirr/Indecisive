using System;
namespace Shared.Utilities.Exceptions
{
    public class ExistArgumentException : Exception
    {
        public Error ValidationError { get; set; }
        public ExistArgumentException(string message, Error error) : base(message)
        {
            ValidationError = error;
            ValidationError.Message = message;
        }
    }
}

