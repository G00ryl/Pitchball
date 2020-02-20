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

            RuleFor(x => x)
                .Must(x => IsDifferenceLessThanTwoHours(x.StartDate, x.EndDate));
        }

        private Func<DateTime, DateTime, bool> IsDifferenceLessThanTwoHours = (DateTime startDate, DateTime endDate) =>
        {
            return (endDate.TimeOfDay - startDate.TimeOfDay) <= TimeSpan.FromHours(2) ? true : false;
        };
    }
}