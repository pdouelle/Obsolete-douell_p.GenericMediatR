using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Delete
{
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommandModel<T>, Unit> where T : IEntity
    {
        protected readonly IRepository<T> Repository;

        public DeleteCommandHandler(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<Unit> Handle(DeleteCommandModel<T> command, CancellationToken cancellationToken)
        {
            Repository.Delete(command.Request);
            
            return Unit.Value;
        }
    }
}