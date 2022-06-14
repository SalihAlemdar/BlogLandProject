using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("İsim kısmını boş geçemezsiniz");
            RuleFor(a => a.SurName).NotEmpty().WithMessage("Soyadı kısmını boş geçemezsiniz");
            RuleFor(a => a.Mail).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz");
            RuleFor(a => a.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz");
            RuleFor(a => a.Message).NotEmpty().WithMessage("Mesaj alanını boş geçemezsiniz");

        }
    }
}
