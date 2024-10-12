using FluentValidation;
using RestaurantApp.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı boş geçilemez.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih boş geçilemez.");


            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithMessage("İsim alanı en az 2 karakter olmalıdır")
                .MaximumLength(50)
                .WithMessage("İsim alanı en fazla 50 karakter olmalıdır");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lutfen gecerli bir email adresini giriniz");
           









        }
    }
}
