using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Account
{
    /// <summary>
    /// Represends a binding class for the registration.
    /// </summary>
    public class CreateAccount
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
