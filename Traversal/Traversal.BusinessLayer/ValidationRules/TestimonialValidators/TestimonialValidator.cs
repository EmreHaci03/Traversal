using FluentValidation;
using Traversal.DtoLayer.DTOS.TestimonialDtos;

namespace Traversal.BusinessLayer.ValidationRules.TestimonialValidators
{
    public class TestimonialValidator : AbstractValidator<CreateTestimonialDto>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Yorum en az 10 karakter olmalıdır.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

            RuleFor(x => x.ClientImageUrl)
                .NotEmpty().WithMessage("Müşteri fotoğrafı URL'si boş bırakılamaz.");
        }
    }
}