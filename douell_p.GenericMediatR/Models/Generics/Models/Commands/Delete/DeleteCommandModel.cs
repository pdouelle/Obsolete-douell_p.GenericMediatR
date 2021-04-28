using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete
{
    public class DeleteCommandModel<TEntity, TDelete> : IRequest<TEntity>
    {
        public TEntity Entity { get; set; }
        public TDelete Request { get; set; }
    }
}