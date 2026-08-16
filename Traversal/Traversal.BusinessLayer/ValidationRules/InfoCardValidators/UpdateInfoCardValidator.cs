
using FluentValidation;
using Traversal.DtoLayer.DTOS.InfoCardDtos;

namespace Traversal.BusinessLayer.ValidationRules.InfoCardValidators
{
    public class UpdateInfoCardValidator : AbstractValidator<UpdateInfoCardDto>
    {
        public UpdateInfoCardValidator()
        {
            RuleFor(x => x.InfoCardId)
                .GreaterThan(0).WithMessage("Geçersiz Bilgi Kartı");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık Boş Bırakılamaz")
                .MaximumLength(100).WithMessage("Başlık En Fazla 100 Karakter Olabilir");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama Boş Bırakılamaz")
                .MaximumLength(500).WithMessage("Açıklama En Fazla 500 Karakter Olabilir");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
        }
    }
}