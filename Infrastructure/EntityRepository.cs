using Domain;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EntityRepository: IEntityRepository
    {
        private readonly IDataContext _context;
        public EntityRepository(IDataContext context)
        {
            _context = context;
        }

        public EntityT GetById(Guid Id)
        { 
            return _context.EntityData.ById(Id).Adapt<EntityT>();
        }
        public List<EntityT> GetAll(Guid Id)
        { 
            return _context.EntityData.Adapt<List<EntityT>>();
        }
        public void Insert(EntityT entity)
        {
            _context.EntityData.Insert(entity.Adapt<EntityTDalDto>());
        }

    }
}
