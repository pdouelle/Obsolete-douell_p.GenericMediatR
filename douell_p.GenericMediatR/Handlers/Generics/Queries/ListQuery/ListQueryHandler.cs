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
        private readonly IRepository<TEntity> _repository;

        public ListQueryHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TEntity>> Handle(ListQueryModel<TEntity, TQueryList> listQuery, CancellationToken cancellationToken) =>
            await _repository.GetAllAsync(cancellationToken);
    }
}