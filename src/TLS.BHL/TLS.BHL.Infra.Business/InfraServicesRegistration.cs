using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Services;
using AEC.ESoft.Infra.Business.Services;

namespace AEC.ESoft.Infra.Business
{
    public static class InfraServiceRegistration
    {
        public static void AddInfraServices(this IServiceCollection services)
        {
            // Caching
            //services.AddSingleton<ICacheInstance, RedisCacheInstance>();
            //services.AddSingleton<ICacheService, RedisCacheService>();

            // Bus service
            //services.AddSingleton<IBusService, BusService>();

            #region BusinessServices
            services.AddScoped<ICategoryService, CategoryService>();
            // Other here
            #endregion
        }
    }
}
