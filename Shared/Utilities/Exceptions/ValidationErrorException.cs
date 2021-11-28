using System;
using Shared.Entities.Concrete;

namespace Shared.Utilities.Exceptions
{
    public class ValidationErrorException:Exception
    {
        public ValidationErrorException(string message, IEnumerable<Error> validationErrors) :base(message)
        {
            ValidationErrors = validationErrors;
        }
        public IEnumerable<Error> ValidationErrors{ get; set; }
    }
}

