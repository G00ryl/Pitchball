using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a reservation model for Entity Framework.
    /// </summary>
    public class Reservation : Entity
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public virtual Captain Captain { get; set; }
        public virtual Pitch Pitch { get; set; }

        public Reservation() : base() { }

        public Reservation(string name, DateTime startDate, DateTime endDate) : base()
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Update(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Update();
        }

        public bool IsOverlaping(Reservation reservation)
        {
            return !(StartDate < reservation.StartDate && EndDate < reservation.StartDate
                || StartDate > reservation.EndDate && EndDate > reservation.EndDate);
        }
    }
}
