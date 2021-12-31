using System;
namespace Shared.Utilities.Exceptions
{
    public class ExistObjectException : Exception
    {
        public Error _error { get; set; }
        public ExistObjectException(string message, Error error) : base(message)
        {
            _error = error;
        }
    }
}

