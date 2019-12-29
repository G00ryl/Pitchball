using Pitchball.Domain.Models.Base;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends an admin model for Entity Framework.
    /// </summary>
    public class Admin : Account
    {
        public Admin() : base()
        {
        }

        public Admin(string name, string surname, string login, string email, byte[] salt, byte[] passwordHash)
            : base(name, surname, login, email, salt, passwordHash)
        {
            Role = "Admin";
        }

        public Admin(int id, string name, string surname, string login, string email, byte[] salt, byte[] passwordHash)
            : this(name, surname, login, email, salt, passwordHash)
        {
            Id = id;
        }
    }
}