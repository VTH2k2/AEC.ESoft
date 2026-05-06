using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.ESoft.Infra.Data.SQL.Repositories;
using AEC.Core;
using AEC.Lib.Data.SQL;

namespace AEC.ESoft.Infra.Data
{
    public static class InfraRepositoriesRegistration
    {
        public static void AddInfraRepositories(this IServiceCollection services)
        {
            // Apply use SQL server
            services.AddLibDataSQL();
            services.AddDbContext<ESoftSqlDbContext>(options =>
            {
                options.UseSqlServer(services.GetConfiguration().GetConnectionString("ESoft"), m => { 
                });
            });
            services.AddScoped<IESoftDbContext>(provider => provider.GetRequiredService<ESoftSqlDbContext>());

            #region repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion
        }
    }
}
