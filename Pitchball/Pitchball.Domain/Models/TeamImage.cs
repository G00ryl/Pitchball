using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class TeamImage : Image
    {
        public int? TeamRef { get; private set; }
        public virtual Team Team { get; set; }

        public TeamImage() : base() { }

        public TeamImage(string content) : base(content) { }
    }
}
