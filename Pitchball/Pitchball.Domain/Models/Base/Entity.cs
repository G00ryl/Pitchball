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
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
