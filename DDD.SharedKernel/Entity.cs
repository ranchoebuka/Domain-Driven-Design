using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        // Most ORM requires this
        protected Entity()
        {
        }

        public override bool Equals(object objectToCompare)
        {
            var entity = objectToCompare as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(objectToCompare);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> otherItem)
        {
            if (otherItem == null)
            {
                return false;
            }
            return this.Id.Equals(otherItem.Id);
        }
    }
}
