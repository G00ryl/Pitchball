using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class Team : Entity
    {
        public string Name { get; private set; }
        public Captain Captain { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
