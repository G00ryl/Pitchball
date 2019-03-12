using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.Commands.Account
{
    public class LoginAccount
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
    }
}
