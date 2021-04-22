using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Queries.IdQuery
{
    public class IdQueryModel<T> : IRequest<T>
    {
        public T Request { get; set; }
    }
}