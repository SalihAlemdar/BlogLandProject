using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.AuthorName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(a => a.AuthorName).MinimumLength(3).WithMessage("Yazar adını en az 3 karakter olmalıdır");
            RuleFor(a => a.AuthorName).MaximumLength(30).WithMessage("Yazar adını en fazla 30 karakter olmalıdır");

            RuleFor(a => a.Mail).NotEmpty().WithMessage("Yazar Mail boş geçemezsiniz");

            RuleFor(a => a.AuthorTitle).NotEmpty().WithMessage("Yazar başlığı boş geçemezsiniz");
            RuleFor(a => a.AuthorTitle).MinimumLength(3).WithMessage("Yazar başlığı en az 3 karakter olmalıdır");
            RuleFor(a => a.AuthorTitle).MaximumLength(30).WithMessage("Yazar başlığı en fazla 30 karakter olmalıdır");

            RuleFor(a => a.AboutShort).NotEmpty().WithMessage("Yazar yeteneği kısmını boş geçemezsiniz");
            RuleFor(a => a.AboutShort).MinimumLength(6).WithMessage("Yazar yeteneği kısmı en az 6 karakter olmalıdır");
            RuleFor(a => a.AboutShort).MaximumLength(50).WithMessage("Yazar yeteneği kısmı en fazla 50 karakter olmalıdır");

            RuleFor(a => a.PhoneNumber).NotEmpty().WithMessage("Telefon bilgisini boş geçemezsiniz");

            RuleFor(a => a.AuthorImage).NotEmpty().WithMessage("Yazar resmi boş geçemezsiniz");

            RuleFor(a => a.Password).NotEmpty().WithMessage("Yazar Şifresini boş geçemezsiniz");
            RuleFor(a => a.Password).MinimumLength(6).WithMessage("Şifre 6 karakter olmalıdır");
            RuleFor(a => a.Password).MaximumLength(6).WithMessage("Şifre 6 karakter olmalıdır");

            RuleFor(a => a.AuthorAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçemezsiniz");
            RuleFor(a => a.AuthorAbout).MinimumLength(3).WithMessage("Yazar hakkında kısmı en az 3 karakter olmalıdır");
            RuleFor(a => a.AuthorAbout).MaximumLength(1000).WithMessage("Yazar hakkında kısmı en fazla 1000 karakter olmalıdır");

           

            
        }
    }
}
