using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(a => a.AboutContent1).NotEmpty().WithMessage("Hakkımızda1 alanı boş geçemezsiniz");
            RuleFor(a => a.AboutContent2).NotEmpty().WithMessage("Hakkımızda2 alanı boş geçemezsiniz");
            RuleFor(a => a.AboutImage1).NotEmpty().WithMessage("Resim1 alanı boş geçemezsiniz");
            RuleFor(a => a.AboutImage2).NotEmpty().WithMessage("Resim2 alanı boş geçemezsiniz");
        }
    }
}
