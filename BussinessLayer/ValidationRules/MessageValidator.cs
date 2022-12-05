using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Mesaj içeriği boş olamaz.");
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Alıcı adresi 3 karakterden fazla olmalıdır.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu 3 karakterden fazla olmalıdır.");
            RuleFor(x => x.Value).MinimumLength(3).WithMessage("Mesaj içeriği 3 karakterden fazla olmalıdır.");
        }
        
    }
}
