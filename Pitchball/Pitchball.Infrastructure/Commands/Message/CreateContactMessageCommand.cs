using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Message
{
    public class CreateContactMessageCommand
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Text { get; set; }
        }
    
}

