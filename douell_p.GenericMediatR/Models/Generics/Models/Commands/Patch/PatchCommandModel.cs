using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Patch
{
    public class PatchCommandModel<TEntity, TPatch> : IRequest<TEntity>
    {
        public TEntity Entity { get; set; }
        public TPatch Request { get; set; }
    }
}