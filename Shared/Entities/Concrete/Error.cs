using System;
namespace Shared.Entities.Concrete
{
    public class Error
    {
        public Error(string propertyName,string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
        public Error(string propertyName)
        {
            PropertyName = propertyName;
        }
        public Error()
        {

        }
        public string? PropertyName { get; set; }
        public string? Message { get; set; }
    }
}

