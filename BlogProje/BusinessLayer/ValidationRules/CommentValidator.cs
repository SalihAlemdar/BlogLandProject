using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Kullanıcı adını alanı boş geçemezsiniz");
            RuleFor(a => a.CommentText).NotEmpty().WithMessage("Yorum alanını alanı boş geçemezsiniz");
            RuleFor(a => a.Mail).NotEmpty().WithMessage("Mail alanı boş geçemezsiniz");
            RuleFor(a => a.BlogRating).NotEmpty().WithMessage("Blog'a Puan veriniz");
        }
    }
}
