using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MarketValidator:AbstractValidator<Market>
    {
        public MarketValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(m => m.Name).Length(2,25).WithMessage("Market adı 2 ile 25 karakter arasında olmalıdır.");
            RuleFor(m => m.Adress).NotEmpty().WithMessage("Bu alan boş geçilemez.Lütfen tam adresi giriniz.");

        }
    }
}
