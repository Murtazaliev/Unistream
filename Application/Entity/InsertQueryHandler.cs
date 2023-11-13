using Application.Common;
using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entity
{
    internal class InsertQueryHandler:IRequestHandler<InsertQuery, EntityT>
    {
        private readonly IEntityRepository _repository;
        public InsertQueryHandler(IEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<EntityT> Handle(InsertQuery request, CancellationToken cancellationToken)
        {
            var entity = JsonTryDeserealizer.ToClass<EntityT>(request.EntityTJson, JsonShemas.EntityTSchemaJson);           
            _repository.Insert(entity);
            return entity;
        }
    }
}
