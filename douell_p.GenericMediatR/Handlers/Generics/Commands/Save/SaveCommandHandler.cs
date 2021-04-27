using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Save;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Save
{
    public class SaveCommandHandler<T> : IRequestHandler<SaveCommandModel<T>, bool> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public SaveCommandHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Handle(SaveCommandModel<T> command, CancellationToken cancellationToken) =>
            await _repository.SaveAsync(cancellationToken);
    }
}