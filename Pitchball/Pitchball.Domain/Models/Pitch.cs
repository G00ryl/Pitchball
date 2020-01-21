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
        public bool IsActive { get; private set; }
		public string Surface { get; private set; }
		public string Lighting { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }

        public virtual PitchImage PitchImage { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Pitch() : base() { }

        public Pitch(string name, bool isActive, string surface, string lighting, string street, string city) : base()
        {
			Name = name;
            IsActive = isActive;
			Surface = surface;
			Lighting = lighting;
            Street = street;
            City = city;
        }
        public Pitch(string name, string surface, string lighting, string street, string city) : base()
        {
            Name = name;
            Surface = surface;
            Lighting = lighting;
            Street = street;
            City = city;
        }

        public void Update(string name, bool isActive, string surface, string lighting, string street, string city)
        {
			Name = name;
            IsActive = isActive;
            Surface = surface;
			Lighting = lighting;
            Street = street;
            City = city;
            Update();
        }
    }
}
