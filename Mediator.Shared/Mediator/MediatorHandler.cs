using System.Threading.Tasks;
using Mediator.Shared.Commands;
using Mediator.Shared.Events;
using MediatR;

namespace Mediator.Shared.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : ICommand
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : IEvent
        {
            //If will necessary save events. It's should do here 

            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : INotification
        {
            return _mediator.Publish(message);
        }

    }
}