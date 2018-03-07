using System.Threading;
using System.Threading.Tasks;
using Mediator.Domain.Commands;
using Mediator.Domain.Contracts;
using Mediator.Domain.Contracts.Repositories;
using Mediator.Domain.Entities;
using Mediator.Domain.Events;
using Mediator.Shared.Mediator;
using Mediator.Shared.Notifications;
using MediatR;

namespace Mediator.Domain.CommandHandlers
{

    public class UserCommandHandler : CommandHandler, 
                INotificationHandler<AddUserCommand>
    {

        private IUserRepository _repository;

        public UserCommandHandler(IUserRepository repository,
                                  IUnitOfWork uow,
                                  IMediatorHandler mediatorHandler,
                                  INotificationHandler<DomainNotification> notifications) : base(uow, mediatorHandler, notifications)
        {
            _repository = repository;
        }

        public Task Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.Valid)
            {
                NotifyValidationErrors(command);
                return Task.FromResult(0);
            }

            var user = new User(command.Username, command.Password, command.Email);

            if (!user.Valid)
            {
                NotifyDomainValidationErrors(user);
                return Task.FromResult(0);
            }

            _repository.Add(user);

            if (Commit())
            {            
                //evento está aqui só para exemplo de como levantar eventos
                _mediatorHandler.RaiseEvent(new AddUserEvent(user.Id, user.Password));
            }

            return Task.FromResult(0);
        }
    }

}