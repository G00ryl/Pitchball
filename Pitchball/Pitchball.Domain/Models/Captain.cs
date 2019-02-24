using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class Captain : Account
    {
        public int TeamRef { get; private set; }
        public Team Team { get; set; }

        public Captain() : base() { }

        public Captain(string name, string surname, string login, byte[] salt, byte[] passwordHash) : base(name, surname, login, salt, passwordHash)
        {
            Role = "Captain";
        }
    }
}
