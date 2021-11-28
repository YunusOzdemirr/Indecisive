using System;
using Shared.Entities.Concrete;

namespace Shared.Utilities.Exceptions
{
    public class NotFoundExceptions:Exception
    {
        public NotFoundExceptions(string message,IEnumerable<Error> errors):base(message)
        {
            Errors = errors;
        }
        public IEnumerable<Error> Errors{ get; set; }
    }
}

