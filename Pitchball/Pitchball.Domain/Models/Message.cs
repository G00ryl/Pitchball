using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class Message : Entity 
    {
        public string Content { get; set; }
        public Account Creator { get; set; }

        public Message() : base() { }
        
    }
}
