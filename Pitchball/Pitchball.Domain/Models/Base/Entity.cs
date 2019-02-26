using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Domain.Models.Base
{
    /// <summary>
    /// Base class for all database models.
    /// </summary>
    public class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
