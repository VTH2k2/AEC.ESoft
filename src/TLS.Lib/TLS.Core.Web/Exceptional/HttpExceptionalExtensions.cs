using AEC.Core;
using AEC.Core.Exceptional;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS.Core.Exceptional
{
    public static class HttpExceptionalExtensions
    {
        private static readonly object _lockService = new object();
        private static IHttpExceptional _httpExceptionalService;
        private static IHttpExceptional HttpExceptionalService
        {
            get
            {
                if (_httpExceptionalService == null)
                {
                    lock (_lockService)
                    {
                        if (_httpExceptionalService == null)
                        {
                            _httpExceptionalService = GetHttpExceptionalService();
                        }
                    }
                }
                return _httpExceptionalService;
            }
        }
        private static IHttpExceptional GetHttpExceptionalService()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                return serviceScope.ServiceProvider.GetRequiredService<IHttpExceptional>();
            }
        }
        /*
        public static void Log(this Exception ex, HttpContext context, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null, string applicationName = null)
        {
            HttpExceptionalService.Log(ex, context, category, rollupPerServer, customData, applicationName);
        }
        public static async Task LogAsync(this Exception ex, HttpContext context, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null, string applicationName = null)
        {
            await HttpExceptionalService.LogAsync(ex, context, category, rollupPerServer, customData, applicationName);
        }

        public static void LogDebug(this HttpContext context, string msg)
        {
            ErrorStore.LogException(new Exception(msg), HttpContext.Current, applicationName: ErrorStore.ApplicationName + "-Debug");
        }
        public static void LogDebug(string msg, object arg0)
        {
            ErrorStore.LogException(new Exception(string.Format(msg, arg0)), HttpContext.Current, applicationName: ErrorStore.ApplicationName + "-Debug");
        }
        public static void LogDebug(string msg, params object[] args)
        {
            ErrorStore.LogException(new Exception(string.Format(msg, args)), HttpContext.Current, applicationName: ErrorStore.ApplicationName + "-Debug");
        }
        public static void LogError(string errMsg)
        {
            LogError(new Exception(errMsg));
        }
        public static void LogError(string errMsg, object arg0)
        {
            LogError(new Exception(string.Format(errMsg, arg0)));
        }
        public static void LogError(string errMsg, params object[] args)
        {
            LogError(new Exception(string.Format(errMsg, args)));
        }
        public static void LogError(Exception ex)
        {
            ErrorStore.LogException(ex, HttpContext.Current);
        }
        */
    }
}
