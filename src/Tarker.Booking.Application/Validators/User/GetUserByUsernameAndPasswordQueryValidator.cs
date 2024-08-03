using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetUserByUsernameAndPasswordQueryValidator : AbstractValidator<(string, string)>
    {
        public GetUserByUsernameAndPasswordQueryValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Item2).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}
