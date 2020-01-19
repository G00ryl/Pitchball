using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class ContactMessage : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }

        public ContactMessage(string name, string email, string text) : base()
        {
            Name = name;
            Email = email;
            Text = text;
        }
    }
}
