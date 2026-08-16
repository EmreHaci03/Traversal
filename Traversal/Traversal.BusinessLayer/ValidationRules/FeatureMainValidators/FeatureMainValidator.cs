using FluentValidation;
using Traversal.DtoLayer.DTOS.FeatureMainDtos;

namespace Traversal.BusinessLayer.ValidationRules.FeatureMainValidators
{
    public class FeatureMainValidator : AbstractValidator<CreateFeatureMainDto>
    {
        public FeatureMainValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
        }
    }
}