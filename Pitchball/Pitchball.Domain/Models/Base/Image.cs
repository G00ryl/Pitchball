using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models.Base
{
    /// <summary>
    /// Represends a image base (container-like) model for Entity Framework.
    /// </summary>
    public abstract class Image : Entity
    {
        public string ImageContent { get; set; }

        public Image() : base() { }

        public Image(string content) : base()
        {
            ImageContent = content;
        }

        public virtual void Update(string content)
        {
            ImageContent = content;
            base.Update();
        }
    }
}
