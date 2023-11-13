using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DataContext:IDataContext
    {

        EntityTData IDataContext.EntityData 
        { 
            get => EntityTData.GetInstance(); 
            set => EntityTData.GetInstance(); 
        }

    }
}
