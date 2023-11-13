using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.Entity
{
    internal class GetByIdQueryHandler:IRequestHandler<GetByIdQuery, EntityT>
    {
        private readonly IEntityRepository _repository;
        public GetByIdQueryHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityT> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(()=> _repository.GetById(request.Id));
        }
    }
}
