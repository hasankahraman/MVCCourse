using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı boş olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar soyadı boş olamaz.");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında alanı boş olamaz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Yazar adı en az 2 karakter olmalıdır.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Yazar soyadı en az 2 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("yazar adı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("yazar soyadı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.About).Matches("a").WithMessage("Hakkında alanında mutlaka 'a' karakteri bulunmalıdır.");

        }
    }
}
