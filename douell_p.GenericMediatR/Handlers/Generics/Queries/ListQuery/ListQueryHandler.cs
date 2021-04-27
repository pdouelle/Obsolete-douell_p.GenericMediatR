using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.ListQuery;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Queries.ListQuery
{
    public class ListQueryHandler<T> : IRequestHandler<ListQueryModel<T>, IEnumerable<T>> where T : IEntity
    {
        protected readonly IRepository<T> Repository;

        public ListQueryHandler(IRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<T>> Handle(ListQueryModel<T> listQuery, CancellationToken cancellationToken) =>
            await Repository.GetAllAsync(cancellationToken);
    }
}