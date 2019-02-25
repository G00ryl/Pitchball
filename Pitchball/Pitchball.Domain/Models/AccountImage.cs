using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a account's image model for Entity Framework.
    /// </summary>
    public class AccountImage : Image
    {
        public int? AccountRef { get; private set; }
        public virtual Account Account { get; set; }

        public AccountImage() : base() { }

        public AccountImage(string content) : base(content) { }
    }
}
