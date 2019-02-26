using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models
{
    /// <summary>
    /// Represends a comment model for Entity Framework.
    /// </summary>
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public virtual Pitch Pitch { get; set; }
        public virtual Account Creator { get; set; }

        public Comment() : base() { }

        public Comment(string content) : base()
        {
            Content = content;
        }

        public void Update(string content)
        {
            Content = content;
            Update();
        }
    }
}
