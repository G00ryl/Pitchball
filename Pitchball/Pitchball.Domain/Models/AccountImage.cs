using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    public class AccountImage : Image
    {
        public int? AccountRef { get; private set; }
        public virtual Account Account { get; set; }

        public AccountImage() : base() { }

        public AccountImage(string content) : base(content) { }
    }
}
