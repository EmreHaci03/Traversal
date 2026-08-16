using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DtoLayer.DTOS.WhyChooseUsDtos;

namespace Traversal.BusinessLayer.ValidationRules.WhyChooseUsValidators
{
    public class WhyChooseUsValidator:AbstractValidator<CreateWhyChooseUsDto>
    {

        public WhyChooseUsValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz")
            .MinimumLength(5).WithMessage("Başlık Alanı en az 5 karakter olmalıdır.");

            RuleFor(x => x.Description)
          .NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz")
          .MinimumLength(10).WithMessage("Açıklama Alanı en az 10 karakter olmalıdır.");
        }
    }
}
