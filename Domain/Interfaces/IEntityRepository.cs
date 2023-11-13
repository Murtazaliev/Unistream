
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEntityRepository
    {
        EntityT GetById(Guid Id);
        List<EntityT> GetAll(Guid Id);
        void Insert(EntityT entity);
    }
}
