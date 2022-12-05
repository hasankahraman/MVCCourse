using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("E-Posta alanı boş olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş olamaz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş olamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı alanı boş olamaz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(250).WithMessage("Konu adı en fazla 250 karakter olmalıdır.");
        }
    }
}
