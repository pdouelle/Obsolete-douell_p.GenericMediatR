using MediatR;

namespace douell_p.GenericMediatR.Models.Generics.Models.Commands.Create
{
    public class CreateCommandModel<T> : IRequest<Unit>
    {
        public T Request { get; set; }
    }
}