using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Mediator.Shared.Mediator;
using Mediator.Domain.Services;
using Mediator.Application.Services;
using MediatR;
using Mediator.Shared.Notifications;
using Mediator.Domain.EventHandlers;
using Mediator.Domain.Events;
using Mediator.Domain.Commands;
using Mediator.Domain.CommandHandlers;
using Mediator.Domain.Contracts.Repositories;
using Mediator.Infra.Data.Repositories;
using Mediator.Domain.Contracts;
using Mediator.Infra.Data.UoW;
using System;

namespace Mediator.Infra.CrossCutting{

    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services, 
                                            IConfiguration configuration, 
                                            Type startupType)
        {  

            // Mediator Handler
             services.AddScoped<IMediatorHandler, MediatorHandler>();
            
            // Application Service
            services.AddScoped<IUserService, UserService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<AddUserEvent>, UserEventHandler>();

            //Domain - Commands
            services.AddScoped<INotificationHandler<AddUserCommand>, UserCommandHandler>();

            // Repositories
            services.AddScoped<IUserRepository, FakeUserRepository>();
            services.AddScoped<IUnitOfWork, FakeUnitOfWork>();

            services.AddMediatR(typeof(FakeUnitOfWork));


        }
    }
}