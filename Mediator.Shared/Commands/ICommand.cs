using System;
using Mediator.Shared.Events;

namespace Mediator.Shared.Commands
{

    public interface ICommand : IMessage
    {
        void Validate();
    }
}