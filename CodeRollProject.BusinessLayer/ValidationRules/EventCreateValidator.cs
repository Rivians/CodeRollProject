using CodeRollProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.ValidationRules
{
    public class EventCreateValidator : AbstractValidator<Event>
    {
        public EventCreateValidator()
        {
            RuleFor(x => x.EventName).NotEmpty().WithMessage("Event adı boş geçilemez.");
            RuleFor(x => x.EventTime).NotEmpty().WithMessage("Event tarihi boş geçilemez.");
            RuleFor(x => x.EventDescription).NotEmpty().WithMessage("Event açıklaması boş geçilemez.");
            RuleFor(x => x.EventPlatform).NotEmpty().WithMessage("Event platformu boş geçilemez.");

            RuleFor(x => x.EventName).MinimumLength(3).WithMessage("Event adı minimum 3 harften oluşmalıdır.");
            RuleFor(x => x.EventDescription).MinimumLength(3).WithMessage("Event açıklaması minimum 3 harften oluşmalıdır.");

            RuleFor(x => x.EventDescription).MaximumLength(20).WithMessage("Event açıklaması maximum 20 harften oluşmalıdır.");
            RuleFor(x => x.EventDescription).MaximumLength(50).WithMessage("Event açıklaması minimum 50 harften oluşmalıdır.");
        }
    }
}
