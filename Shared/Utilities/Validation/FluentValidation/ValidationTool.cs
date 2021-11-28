using System;
using FluentValidation;
using Shared.Entities.Concrete;
using Shared.Utilities.Exceptions;

namespace Shared.Utilities.Validation.FluentValidation
{
    public class ValidationTool
    {
       public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                IList<Error> validationErrors = new List<Error>();
                foreach (var error in validationErrors)
                {
                    validationErrors.Add(new Error
                    {
                        Message=error.Message,
                        PropertyName=error.PropertyName
                    });
                }
                throw new NotFoundExceptions("Bir veya daha fazla validasyon hatası ile karşılaşıldı", validationErrors);
            }
        }
    }
}

