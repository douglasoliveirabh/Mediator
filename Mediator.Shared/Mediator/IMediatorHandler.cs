using System.Threading.Tasks;
using Mediator.Shared.Commands;
using Mediator.Shared.Events;

namespace Mediator.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : ICommand;
        Task RaiseEvent<T>(T @event) where T : IEvent;
    }
}