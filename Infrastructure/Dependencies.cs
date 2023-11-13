using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInfrastructury
    {
        public static void AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddTransient<IEntityRepository, EntityRepository>();
            services.AddTransient<IDataContext, DataContext>();
        }
    }
}
