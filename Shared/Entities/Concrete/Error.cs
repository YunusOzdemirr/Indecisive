using System;
namespace Shared.Entities.Concrete
{
    public class Error
    {
        public Error(string message, string propertyName)
        {
            Message = message;
            PropertyName = propertyName;
        }
        public Error(string message)
        {
            Message = message;
        }
        public Error()
        {

        }
        public string? PropertyName { get; set; }
        public string? Message { get; set; }
    }
}

