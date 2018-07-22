using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
