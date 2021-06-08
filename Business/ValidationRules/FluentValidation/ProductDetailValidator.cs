using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductDetailValidator:AbstractValidator<Product>
    {
        public ProductDetailValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Bu alan boş geçilemez.");

        }
    }
}
