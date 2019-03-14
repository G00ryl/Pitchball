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
		public string Name { get; private set; }
		public string Address { get; private set; }
        public bool IsActive { get; private set; }
		public string Surface { get; private set; }
		public string Lighting { get; private set; }
		

		public virtual PitchImage PitchImage { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Pitch() : base() { }

        public Pitch(string name, string address, bool isActive, string surface, string lighting) : base()
        {
			Name = name;
            Address = address;
            IsActive = isActive;
			Surface = surface;
			Lighting = lighting;
        }

        public void Update(string name, string address, bool isActive, string lighting)
        {
			Name = name;
            Address = address;
            IsActive = isActive;
			Lighting = lighting;
            Update();
        }
    }
}
