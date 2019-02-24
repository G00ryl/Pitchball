using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models.Base
{
    /// <summary>
    /// Represends an account base (container-like) model for Entity Framework.
    /// </summary>
    public abstract class Account : Entity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Login { get; protected set; }
        public string Email { get; protected set; }
        public byte[] Salt { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public string Role { get; protected set; }
        public ICollection<Comment> Comments { get; set; }

        public Account() : base() { }

        public Account(string name, string surname, string login, byte[] salt, byte[] passwordHash) : base()
        {
            Name = name;
            Surname = surname;
            Login = login;
            Salt = salt;
            PasswordHash = passwordHash;
        }

        public void Update(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Update();
        }
    }
}
