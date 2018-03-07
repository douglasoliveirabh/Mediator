using System;
using Mediator.Shared.Events;

namespace Mediator.Domain.Events
{
    public class AddUserEvent : EventBase
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }

        public AddUserEvent(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}