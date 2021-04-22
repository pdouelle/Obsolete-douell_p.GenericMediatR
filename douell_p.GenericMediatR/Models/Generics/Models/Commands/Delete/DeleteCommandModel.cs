using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Delete
{
    public class DeleteCommandModel<T> : IRequest<Unit>
    {
        public T Request { get; set; }
    }
}