using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Team
{
    public class CreateTeam
    {
        [Required]
        [MinLength(4)]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
