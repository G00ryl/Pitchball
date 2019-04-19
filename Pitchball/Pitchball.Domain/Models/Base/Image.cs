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
        public string ImageType { get; protected set; }

        public Image() : base() { }

        public Image(byte[] content, string type) : base()
        {
            ImageContent = content;
            ImageType = type;
        }

        public virtual void Update(byte[] content, string type)
        {
            ImageContent = content;
            ImageType = type;
            Update();
        }
    }
}
