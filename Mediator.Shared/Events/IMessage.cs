using MediatR;

namespace Mediator.Shared.Events {

    public interface IMessage : INotification
    {
        string MessageType { get; }
    }
}