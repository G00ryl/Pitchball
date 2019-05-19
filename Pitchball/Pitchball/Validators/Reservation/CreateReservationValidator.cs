using FluentValidation;
using Pitchball.Infrastructure.Commands.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Validators.Reservation
{
    public class CreateReservationValidator : AbstractValidator<CreateReservation>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .GreaterThan(DateTime.UtcNow)
                .LessThan(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThan(x => x.StartDate);
        }
    }
}
