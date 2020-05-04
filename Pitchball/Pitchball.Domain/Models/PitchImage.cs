using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a pitch's image model for Entity Framework.
    /// </summary>
    public class PitchImage : Image
    {
        public int? PitchId { get; private set; }
        public virtual Pitch Pitch { get; set; }

        public PitchImage() : base()
        {
        }

        public PitchImage(byte[] content, string type) : base(content, type)
        {
        }
    }
}