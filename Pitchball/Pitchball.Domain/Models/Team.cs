using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a team model for Entity Framework.
    /// </summary>
    public class Team : Entity
    {
        public string Name { get; private set; }
        public virtual Captain Captain { get; set; }
        public virtual TeamImage TeamImage { get; set; }
        public virtual ICollection<User> Members { get; set; }
    }
}
