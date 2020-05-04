using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a captain model for Entity Framework.
    /// </summary>
    public class Captain : Account
    {
        public int TeamId { get; private set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Captain() : base()
        {
        }

        public Captain(string name, string surname, string login, string email, byte[] salt, byte[] passwordHash)
            : base(name, surname, login, email, salt, passwordHash)
        {
            Role = "Captain";
        }
    }
}