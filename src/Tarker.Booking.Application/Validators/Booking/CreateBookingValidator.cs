using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull().MaximumLength(8);
            RuleFor(x => x.Type).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.CustomerId).GreaterThan(0).NotNull();
            RuleFor(x => x.UserId).GreaterThan(0).NotNull();
        }
    }
}
