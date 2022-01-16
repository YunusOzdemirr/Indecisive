using System;
using Entities.Concrete;
using FluentValidation;

namespace Services.ValidationRules.FluentValidation.ProductValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
        }

    }
}

