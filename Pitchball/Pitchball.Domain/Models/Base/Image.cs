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
        public byte[] ImageContent { get; protected set; }

        public Image() : base() { }

        public Image(byte[] content) : base()
        {
            ImageContent = content;
        }

        public virtual void Update(byte[] content)
        {
            ImageContent = content;
            Update();
        }
    }
}
