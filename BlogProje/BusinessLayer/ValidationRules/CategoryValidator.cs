using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(a => a.CategoryName).MinimumLength(3).WithMessage("Kategori adını en az 3 karakter olmalıdır");
            RuleFor(a => a.CategoryName).MaximumLength(30).WithMessage("Kategori adını en fazla 30 karakter olmalıdır");
            RuleFor(a => a.CategoryDescreption).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz");

        }
    }
}
