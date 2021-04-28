using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Create
{
    public class CreateCommandModel<TEntity, TCreate> : IRequest<TEntity>
    {
        public TCreate Request { get; set; }
    }
}