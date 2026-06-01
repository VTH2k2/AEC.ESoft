using AEC.Core;
using AEC.Core.Exceptional;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Exceptional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS.Core;
using AEC.Core.Application;
using AEC.Core.Configure;
using TLS.Core.Exceptional;
using AEC.Core.Web;
using static Dapper.SqlMapper;

namespace AEC.Lib.Exceptional
{
    public static class LibExceptionalRegistration
    {
        private const string DefaultExceptionalConfigKey = "Exceptional";

        /// <summary>
        /// Add lib StackExchangeExceptional use default config section ["Exceptional"]
        /// </summary>
        /// <param name="services"></param>
        /// <param name="isOnlyForJob"></param>
        /// <returns></returns>
        public static IServiceCollection AddLibExceptional<TExceptional>(this IServiceCollection services, bool isOnlyForJob = false)
            where TExceptional : IExceptional
        {
            // Check param
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Use default section
            var configuration = services.GetConfiguration();
            var section = configuration.GetSection(DefaultExceptionalConfigKey);
            if (!section.Exists())
            {
                throw new Exception($"Configuration section [{DefaultExceptionalConfigKey}] was not found");
            }

            return AddLibExceptional<TExceptional>(services, section, isOnlyForJob);
        }

        /// <summary>
        /// Add lib StackExchangeExceptional use special config section
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddLibExceptional<TExceptional>(this IServiceCollection services, IConfigurationSection configurationSection, bool isOnlyForJob = false)
            where TExceptional : IExceptional
        {
            // Check param
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Check param
            if (configurationSection == null)
            {
                throw new ArgumentNullException(nameof(configurationSection));
            }

            // Check param
            if (!configurationSection.Exists())
            {
                throw new Exception($"Configuration section [{configurationSection.Key}] was not found");
            }

            if (isOnlyForJob)
            {
                var appSettings = services.GetApplicationSettings();
                var exceptionalSettings = configurationSection.Get<ExceptionalSettings>();
                StackExchange.Exceptional.Exceptional.Configure(exceptionalSettings);

                StackExchange.Exceptional.Exceptional.Settings.Store.ApplicationName = appSettings.Application;
                StackExchange.Exceptional.Exceptional.Settings.UseExceptionalPageOnThrow = appSettings.Environment.IsDevelopment();

                services.AddTransient(typeof(IExceptional), typeof(TExceptional));

                return services;
            }

            // Make IOptions<ExceptionalSettings> available for injection everywhere
            services.AddExceptional(configurationSection, settings =>
            {
                var appSettings = services.GetApplicationSettings();
                settings.Store.ApplicationName = appSettings.Application;
                settings.UseExceptionalPageOnThrow = appSettings.Environment.IsDevelopment();
                settings.GetIPAddress = m =>
                {
                    return m.GetClientIP();
                };
            });
            //services.AddSingleton<IExceptional, StackExchangeExceptional>();
            //services.AddSingleton<IExceptional, StackExchangeHttpExceptional>();
            services.AddTransient(typeof(IExceptional), typeof(TExceptional));
            return services;
        }
    }
}
