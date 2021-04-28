using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Queries.IdQuery
{
    public class IdQueryModel<TEntity, TQueryById> : IRequest<TEntity>
    {
        public TQueryById Request { get; set; }
    }
}