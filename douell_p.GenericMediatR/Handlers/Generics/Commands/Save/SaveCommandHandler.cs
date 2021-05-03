using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Save;
using MediatR;
using pdouelle.Entity;
using pdouelle.GenericRepository;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Save
{
    public class SaveCommandHandler<T> : IRequestHandler<SaveCommandModel<T>, bool> where T : IEntity
    {
        protected readonly IRepository<T> Repository;

        public SaveCommandHandler(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<bool> Handle(SaveCommandModel<T> command, CancellationToken cancellationToken) =>
            await Repository.SaveAsync(cancellationToken);
    }
}