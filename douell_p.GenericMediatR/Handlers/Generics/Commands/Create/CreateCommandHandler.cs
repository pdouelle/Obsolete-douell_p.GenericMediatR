using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Create;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Create
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommandModel<T>, Unit> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public CreateCommandHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Unit> Handle(CreateCommandModel<T> command, CancellationToken cancellationToken)
        {
            _repository.Create(command.Request);

            return Unit.Value;
        }
    }
}