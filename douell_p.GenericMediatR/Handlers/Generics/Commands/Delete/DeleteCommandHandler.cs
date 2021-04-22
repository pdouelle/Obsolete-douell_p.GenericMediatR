using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Delete
{
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommandModel<T>, Unit> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public DeleteCommandHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCommandModel<T> command, CancellationToken cancellationToken)
        {
            _repository.Delete(command.Request);
            
            return Unit.Value;
        }
    }
}