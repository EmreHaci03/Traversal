using FluentValidation;
using Traversal.DtoLayer.DTOS.AboutDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.BusinessLayer.ValidationRules.AboutValidators
{
    public class AboutValidator : AbstractValidator<CreateAboutDto>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Başlık en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
        }
    }
}