using System;
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
        private readonly IRepository<T> _repository;

        public ListQueryHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> Handle(ListQueryModel<T> listQuery, CancellationToken cancellationToken) =>
            await _repository.GetAllAsync(cancellationToken);
    }
}