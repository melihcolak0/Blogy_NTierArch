using _04PC_BlogStore.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.BusinessLayer.ValidationRules
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık en az 5 karakter olmalıdır!");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Başlık en fazla 100 karakter alabilir!");
        }
    }
}
