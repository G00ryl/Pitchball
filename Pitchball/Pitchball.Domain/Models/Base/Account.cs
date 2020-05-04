using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models.Base
{
    /// <summary>
    /// Represends an account base (container-like) model for Entity Framework.
    /// </summary>
    public class Account : Entity
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Login { get; protected set; }
        public string Email { get; protected set; }
        public byte[] Salt { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public string Role { get; protected set; }
        public virtual AccountImage AccountImage { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public Account() : base()
        {
        }

        public Account(string name, string surname, string login, string email, byte[] salt, byte[] passwordHash) : base()
        {
            Name = name;
            Surname = surname;
            Login = login;
            Email = email;
            Salt = salt;
            PasswordHash = passwordHash;
        }

        public void Update(string name, string surname, byte[] passwordHash)
        {
            Name = name;
            Surname = surname;
            PasswordHash = passwordHash;
            Update();
        }
    }
}