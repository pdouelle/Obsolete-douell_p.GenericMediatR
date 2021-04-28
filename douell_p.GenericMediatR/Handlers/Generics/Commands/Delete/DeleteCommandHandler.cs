using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Delete
{
    public class DeleteCommandHandler<TEntity, TDelete> : IRequestHandler<DeleteCommandModel<TEntity, TDelete>, TEntity>
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;

        public DeleteCommandHandler(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<TEntity> Handle
            (DeleteCommandModel<TEntity, TDelete> command, CancellationToken cancellationToken)
        {
            Repository.Delete(command.Entity);

            return command.Entity;
        }
    }
}