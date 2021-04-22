using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Update
{
    public class UpdateCommandModel<T> : IRequest<Unit>
    {
        public T Request { get; set; }
    }
}