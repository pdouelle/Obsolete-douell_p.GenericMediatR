using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using douell_p.GenericMediatR.Models.Generics.Models.Commands.Create;
using douell_p.GenericRepository;
using MediatR;

namespace douell_p.GenericMediatR.Handlers.Generics.Commands.Create
{
    public class CreateCommandHandler<TEntity, TCreate> : IRequestHandler<CreateCommandModel<TEntity, TCreate>, TEntity>
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TEntity> Handle(CreateCommandModel<TEntity, TCreate> command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(command.Request);

            Repository.Create(entity);

            return entity;
        }
    }
}