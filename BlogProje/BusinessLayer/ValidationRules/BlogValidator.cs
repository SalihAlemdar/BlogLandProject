using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(a => a.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçemezsiniz");
            RuleFor(a => a.BlogTitle).MinimumLength(3).WithMessage("Blog başlığı en az 3 karakter olmalıdır");
            RuleFor(a => a.BlogTitle).MaximumLength(30).WithMessage("Blog başlığı en fazla 30 karakter olmalıdır");
            RuleFor(a => a.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçemezsiniz");
            RuleFor(a => a.BlogContent).MinimumLength(3).WithMessage("Blog içeriği en az 3 karakter olmalıdır");
            RuleFor(a => a.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçemezsiniz");
        }
    }
}
