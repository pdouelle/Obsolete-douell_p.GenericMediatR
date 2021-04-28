using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.ListQuery;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Queries.ListQuery
{
    public class ListQueryHandler<TEntity, TQueryList> : IRequestHandler<ListQueryModel<TEntity, TQueryList>, IEnumerable<TEntity>> 
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;

        public ListQueryHandler(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<TEntity>> Handle(ListQueryModel<TEntity, TQueryList> listQuery, CancellationToken cancellationToken) =>
            await Repository.GetAllAsync(cancellationToken);
    }
}