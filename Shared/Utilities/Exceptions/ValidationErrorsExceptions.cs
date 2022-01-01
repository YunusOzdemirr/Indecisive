using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Utilities.Exceptions
{
    public class ValidationErrorsExceptions : Exception
    {
        public IEnumerable<Error> ValidationErrors { get; set; }

        public ValidationErrorsExceptions(string message, IEnumerable<Error> errors) : base(message)
        {
            ValidationErrors = errors;
        }
    }
}