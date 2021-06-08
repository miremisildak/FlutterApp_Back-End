using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductImageValidator : AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(m => m.ProductId).NotEmpty();

        }
    }
}
