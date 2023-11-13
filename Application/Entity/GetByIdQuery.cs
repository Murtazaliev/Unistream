using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entity
{
    public class GetByIdQuery : IRequest<EntityT>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            
            Id = id != Guid.Empty ? id: throw new ArgumentNullException("Параметр Id не указан");
        }
    }
}
