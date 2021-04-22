using System.Collections.Generic;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Queries.ListQuery
{
    public class ListQueryModel<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : IEntity
    {
        public TEntity Request { get; set; }
    }
}