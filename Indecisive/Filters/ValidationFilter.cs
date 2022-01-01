using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Utilities;
using Shared.Entities.Concrete;
using Shared.Utilities.Exceptions;

namespace Indecisive.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                List<Error> validationErrors = new List<Error>();
                foreach (var modelStateKey in context.ModelState.Keys)
                {
                    foreach (var error in context.ModelState[modelStateKey].Errors)
                    {
                        Error modelStateError = new Error
                        {
                            PropertyName = modelStateKey,
                            Message = error.ErrorMessage
                        };
                        validationErrors.Add(modelStateError);
                    }
                }
                throw new ValidationErrorsExceptions(Messages.General.ValidationError(), validationErrors);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}