using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Account
{
    public class UpdateAccount
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
