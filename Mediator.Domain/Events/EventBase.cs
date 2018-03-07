using System;
using Mediator.Shared.Events;

namespace Mediator.Domain.Events {
    public abstract class EventBase : IEvent
    {
        public DateTime Timestamp { get; }
        public string MessageType { get; }

        public EventBase()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
        
    }
}