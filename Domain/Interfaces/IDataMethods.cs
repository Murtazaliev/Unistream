using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDataMethods<T> where T : class
    {
        T ById(Guid id);
        void Insert(T entity);
    }
}
