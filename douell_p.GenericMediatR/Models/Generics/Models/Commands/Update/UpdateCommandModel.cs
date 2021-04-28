using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Update
{
    public class UpdateCommandModel<TEntity, TUpdate> : IRequest<TEntity>
    {
        public TEntity Entity { get; set; }
        public TUpdate Request { get; set; }
    }
}