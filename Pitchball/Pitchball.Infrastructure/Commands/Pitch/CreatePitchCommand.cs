using System;
using System.Collections.Generic;
using System.Text;
using Pitchball.Infrastructure.Commands;

namespace Pitchball.Infrastructure.Commands.Pitch
{
    public class CreatePitchCommand
    {
        public string Name { get; set; }
        public string Surface { get; set; }
        public string Lightning { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
