using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Events;
using MediatR;

namespace Mediator.Domain.EventHandlers {

    public class UserEventHandler : INotificationHandler<AddUserEvent>
    {
        public Task Handle(AddUserEvent notification, CancellationToken cancellationToken)
        {
            // event handle
            return Task.FromResult(0);
        }
    }
}