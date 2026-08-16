using FluentValidation;
using Traversal.DtoLayer.DTOS.GuideDtos;

namespace Traversal.BusinessLayer.ValidationRules.GuideValidators
{
    public class GuideValidator : AbstractValidator<CreateGuideDto>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Fotoğraf URL'si boş bırakılamaz.");

            RuleFor(x => x.TwitterUrl)
                .Matches(@"^https?://.*").WithMessage("Geçerli bir Twitter URL'si giriniz.")
                .When(x => !string.IsNullOrEmpty(x.TwitterUrl));

            RuleFor(x => x.InstagramUrl)
                .Matches(@"^https?://.*").WithMessage("Geçerli bir Instagram URL'si giriniz.")
                .When(x => !string.IsNullOrEmpty(x.InstagramUrl));
        }
    }
}