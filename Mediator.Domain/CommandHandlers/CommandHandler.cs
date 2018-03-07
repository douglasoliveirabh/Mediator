using Flunt.Notifications;
using Mediator.Domain.Commands;
using Mediator.Domain.Contracts;
using Mediator.Domain.Entities;
using Mediator.Shared.Mediator;
using Mediator.Shared.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.Domain.CommandHandlers
{

    public class CommandHandler
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMediatorHandler _mediatorHandler;
        protected readonly DomainNotificationHandler _notifications;


        public CommandHandler(IUnitOfWork uow,
                              IMediatorHandler mediatorHandler,
                              INotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected void NotifyValidationErrors(CommandBase command)
        {
            command.Validate();
            Notify(command.Notifications);
        }

        protected void NotifyDomainValidationErrors(EntityBase entity)
        {
            entity.Validate();
            Notify(entity.Notifications);
        }

        private void Notify(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var error in notifications)
            {
                _mediatorHandler.RaiseEvent(new DomainNotification(error.Property, error.Message));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            _mediatorHandler.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }

    }

}