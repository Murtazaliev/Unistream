using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entity
{
    public class InsertQuery : IRequest<EntityT>
    {
        public string EntityTJson { get; }
        public InsertQuery(string entityTJson)
        {
            if (string.IsNullOrEmpty(entityTJson))
                throw new ArgumentNullException(nameof(entityTJson));
            EntityTJson = entityTJson;
        }
    }
}
