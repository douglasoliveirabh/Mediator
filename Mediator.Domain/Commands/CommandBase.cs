using System;
using Flunt.Notifications;
using Mediator.Shared.Commands;

namespace Mediator.Domain.Commands
{
    public abstract class CommandBase : Notifiable, ICommand
    {
        public DateTime Timestamp { get; }
        public string MessageType { get; }

        public CommandBase()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }

        public abstract void Validate();
    }
}