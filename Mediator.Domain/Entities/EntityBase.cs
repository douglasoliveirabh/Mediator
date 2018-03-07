using System;
using Flunt.Notifications;

namespace Mediator.Domain.Entities {
    public abstract class EntityBase : Notifiable
    {
        public Guid Id { get; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validate();
    }
}