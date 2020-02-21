using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Reservation
{
    public class CreateReservation
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsIntervalLessThanTwoHours { get => IsDifferenceLessThanTwoHours(); }

        private bool IsDifferenceLessThanTwoHours()
        {
            return (EndDate.TimeOfDay - StartDate.TimeOfDay) <= TimeSpan.FromHours(2) ? true : false;
        }
    }
}