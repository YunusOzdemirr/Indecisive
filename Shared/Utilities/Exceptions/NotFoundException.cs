namespace Shared.Utilities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, string errorMessage, string PropertyName) : base(message)
        {
            ValidationError.PropertyName = PropertyName;
            ValidationError.Message = errorMessage;
        }
        public NotFoundException(string message, Error error) : base(message)
        {
            ValidationError = error;
        }
        public Error ValidationError { get; set; }
    }
}

