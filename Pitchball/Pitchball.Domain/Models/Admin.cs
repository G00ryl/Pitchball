using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class Admin : Account
    {
        public Admin() : base() { }

        public Admin(string name, string surname, string login, byte[] salt, byte[] passwordHash) : base(name, surname, login, salt, passwordHash)
        {
            Role = "Admin";
        }
    }
}
