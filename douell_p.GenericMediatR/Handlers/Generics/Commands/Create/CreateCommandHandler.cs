using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Create;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Create
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommandModel<T>, Unit> where T : IEntity
    {
        protected readonly IRepository<T> Repository;

        public CreateCommandHandler(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<Unit> Handle(CreateCommandModel<T> command, CancellationToken cancellationToken)
        {
            Repository.Create(command.Request);

            return Unit.Value;
        }
    }
}