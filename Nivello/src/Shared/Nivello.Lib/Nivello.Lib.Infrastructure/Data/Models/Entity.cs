using System;

namespace Nivello.Lib.Nivello.Lib.Domain.Data.Models
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
