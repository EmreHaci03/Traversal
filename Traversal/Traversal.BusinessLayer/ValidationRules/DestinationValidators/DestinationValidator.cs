using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DtoLayer.DTOS.DestinationDtos;

namespace Traversal.BusinessLayer.ValidationRules.DestinationValidators
{
    public class DestinationValidator:AbstractValidator<CreateDestinationDto>
    {
        public DestinationValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Şehir adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Şehir adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.DayNight)
                .NotEmpty().WithMessage("Süre bilgisi boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Süre bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000000).WithMessage("Fiyat çok yüksek görünüyor, kontrol edin.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(500).WithMessage("Kapasite çok yüksek görünüyor, kontrol edin.");

            RuleFor(x => x.CoverImage)
                .NotEmpty().WithMessage("Kapak görseli boş bırakılamaz.");

            RuleFor(x => x.Details1)
                .NotEmpty().WithMessage("Tur programı (Bölüm 1) boş bırakılamaz.");

            RuleFor(x => x.Details2)
                .NotEmpty().WithMessage("Tur programı (Bölüm 2) boş bırakılamaz.");

            RuleFor(x => x.Image2)
                .NotEmpty().WithMessage("İkinci görsel boş bırakılamaz.");
        }
    }
}
