using System;
using Mediator.Shared.Commands;

namespace Mediator.Domain.Contracts{
    public interface IUnitOfWork: IDisposable
    {        
        CommandResponse Commit();
    }
}