﻿using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public interface IDataContext
    {
        public EntityTData EntityData { get; set; }
    }
}
