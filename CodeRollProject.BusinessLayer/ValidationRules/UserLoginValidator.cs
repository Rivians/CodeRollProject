using CodeRollProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.ValidationRules
{
    public class UserLoginValidator : AbstractValidator<User>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email boş geçilemez.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz.");
        }
    }
}
