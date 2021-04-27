using System.Threading;
using System.Threading.Tasks;
using douell_p.GenericMediatR.Models.Generics.Models.Queries.IdQuery;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Queries.IdQuery
{
    public class IdQueryHandler<T> : IRequestHandler<IdQueryModel<T>, T> where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public IdQueryHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> Handle(IdQueryModel<T> idQuery, CancellationToken cancellationToken) =>
            await _repository.GetByIdAsync(idQuery.Request.Id);
    }
}