using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Update;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Update
{
    public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommandModel<T>, Unit> where T : IEntity
    {
        protected readonly IRepository<T> Repository;

        public UpdateCommandHandler(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<Unit> Handle(UpdateCommandModel<T> command, CancellationToken cancellationToken)
        {
            Repository.Edit(command.Request);

            return Unit.Value;
        }
    }
}