using CodeRollProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.ValidationRules
{
    public class ChooseAvailabilityValidator : AbstractValidator<Vote>
    {
        public ChooseAvailabilityValidator()
        {
            //RuleFor(x => x.VoteOptions).NotEmpty().WithMessage("Lütfen en az 1 seçeneği işaretleyiniz.");
        }
    }
}
