using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class EntityTData : IDataMethods<EntityTDalDto>
    {
        private static EntityTData instance;

        private List<EntityTDalDto> EntityT { get; set; }
        protected EntityTData()
        {
            EntityT = new List<EntityTDalDto>();
        }

        public static EntityTData GetInstance()
        {
            if (instance == null)
                instance = new EntityTData();
            return instance;
        }


        public IEnumerator<EntityTDalDto> GetEnumerator()
        {
            foreach(var item in EntityT)
            {
                yield return item;
            }
        }
        public EntityTDalDto ById(Guid id)
        {
            return EntityT.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException("Элемента с таким Id не существует");
        }

        public void Insert(EntityTDalDto entity)
        {
            if (EntityT.Any(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException("Объект с таким Id уже существует");
            }
            EntityT.Add(entity);
        }
    }
}
