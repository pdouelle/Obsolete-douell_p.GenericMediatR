using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.IdQuery;
using MediatR;
using pdouelle.Entity;
using pdouelle.GenericRepository;

namespace douell_p.GenericMediatR.Handlers.Generics.Queries.IdQuery
{
    public class IdQueryHandler<TEntity, TQueryById> : IRequestHandler<IdQueryModel<TEntity, TQueryById>, TEntity>
        where TEntity : IEntity
        where TQueryById : IEntity
    {
        protected readonly IRepository<TEntity> Repository;

        public IdQueryHandler(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<TEntity> Handle(IdQueryModel<TEntity, TQueryById> query,
            CancellationToken cancellationToken) =>
            await Repository.GetByIdAsync(query.Request.Id);
    }
}