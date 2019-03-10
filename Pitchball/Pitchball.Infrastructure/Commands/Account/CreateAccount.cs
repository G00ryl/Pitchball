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
        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
