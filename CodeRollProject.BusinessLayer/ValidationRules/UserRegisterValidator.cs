using CodeRollProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRollProject.BusinessLayer.ValidationRules
{
	public class UserRegisterValidator : AbstractValidator<User>
	{
        public UserRegisterValidator()
        {
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Email alanı boş geçilemez.");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Email alanı boş geçilemez.");

			RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim alanı en az 2 karaterden oluşmalıdır.");
			RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifreniz en az 6 karakterden oluşmalıdır.");			

			RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim alanı en fazla 20 karakterden oluşmalıdır.");
			RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre alanı en fazla 20 karakterden oluşmalıdır.");

			RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreleriniz eşleşmiyor.");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
		}
    }
}
