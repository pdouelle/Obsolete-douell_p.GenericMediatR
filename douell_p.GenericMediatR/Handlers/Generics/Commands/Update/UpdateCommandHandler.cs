using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Update;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Update
{
    public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommandModel<T>, Unit> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public UpdateCommandHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommandModel<T> command, CancellationToken cancellationToken)
        {
            _repository.Edit(command.Request);

            return Unit.Value;
        }
    }
}