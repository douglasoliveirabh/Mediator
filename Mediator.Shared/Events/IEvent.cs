using System;

namespace Mediator.Shared.Events
{
    public interface IEvent : IMessage
    {        
        DateTime Timestamp { get; }
    }
}