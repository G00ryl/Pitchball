using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.ViewModels.Account
{
    public class AccountSettingsViewModel
    {
        public Domain.Models.Base.Account Account { get; set; }
        public UpdateAccount Command { get; set; }
    }
}
