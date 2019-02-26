using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a team's image model for Entity Framework.
    /// </summary>
    public class TeamImage : Image
    {
        public int? TeamRef { get; private set; }
        public virtual Team Team { get; set; }

        public TeamImage() : base() { }

        public TeamImage(string content) : base(content) { }
    }
}
