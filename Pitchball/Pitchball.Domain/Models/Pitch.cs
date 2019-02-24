using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a football pitch model for Entity Framework.
    /// </summary>
    public class Pitch : Entity
    {
        public string Address { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime OpeningHours { get; private set; }
        public DateTime ClosingHours { get; private set; }

        public Pitch() : base() { }

        public Pitch(string address, bool isActive, DateTime openingHours, DateTime closingHours) : base()
        {
            Address = address;
            IsActive = isActive;
            OpeningHours = openingHours;
            ClosingHours = closingHours;
        }

        public void Update(string address, bool isActive, DateTime openingHours, DateTime closingHours)
        {
            Address = address;
            IsActive = isActive;
            OpeningHours = openingHours;
            ClosingHours = closingHours;
            Update();
        }
    }
}
