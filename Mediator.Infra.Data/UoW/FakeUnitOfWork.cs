using Mediator.Domain.Contracts;
using Mediator.Shared.Commands;

namespace Mediator.Infra.Data.UoW {


    public class FakeUnitOfWork : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return CommandResponse.Ok;
        }

        public void Dispose()
        {
            
        }
    }
}