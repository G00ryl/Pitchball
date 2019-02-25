using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a user model for Entity Framework.
    /// </summary>
    public class User : Account
    {
        public Team Team { get; set; }

        public User() : base() { }

        public User(string name, string surname, string login, byte[] salt, byte[] passwordHash) : base(name, surname, login, salt, passwordHash)
        {
            Role = "User";
        }
    }
}
