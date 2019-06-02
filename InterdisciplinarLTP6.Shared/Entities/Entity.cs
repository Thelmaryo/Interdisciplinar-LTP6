using FluentValidator;
using System;

namespace InterdisciplinarLTP6.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
    }
}
