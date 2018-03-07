using System;
using Mediator.Shared.Events;

namespace Mediator.Shared.Notifications
{
    public class DomainNotification : IEvent
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DateTime Timestamp { get; }

        public string MessageType => GetType().Name;

        string IMessage.MessageType { get => GetType().Name; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}