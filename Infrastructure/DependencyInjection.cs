
using Infrastructure.Database;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Registrera MockDatabase som singleton (en instans för hela applikationen)
            services.AddSingleton<FakeDatabase>();
            return services;
        }
    }
}
