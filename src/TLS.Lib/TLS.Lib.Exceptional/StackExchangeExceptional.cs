using AEC.Core.Exceptional;
using AEC.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Exceptional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Exceptional;
using AEC.Core.Service;

namespace AEC.Lib.Exceptional
{
    public class StackExchangeExceptional : ServiceBase<StackExchangeExceptional>, IExceptional
    {
        private const string DebugPrefix = "";
        private const string DebugSurfix = "-Debug";
        private string DebugApplicationName { get; set; }
        public StackExchangeExceptional(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            DebugApplicationName = string.Format("{0}{1}{2}", DebugPrefix, StackExchange.Exceptional.Exceptional.Settings.Store.ApplicationName, DebugSurfix);
        }

        public new TException LogError<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception
        {
            StackExchange.Exceptional.Extensions.LogNoContext(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogError(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(errorMessage);
            StackExchange.Exceptional.Extensions.LogNoContext(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogError(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(errorMessage, innerException);
            StackExchange.Exceptional.Extensions.LogNoContext(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogError(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var errorMessage = $"Exception {innerException.Message} with input {JsonConvert.SerializeObject(inputError)}";
            return LogError(errorMessage, innerException, category, rollupPerServer, customData);
        }

        public new async Task<TException> LogErrorAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception
        {
            await StackExchange.Exceptional.Extensions.LogNoContextAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogErrorAsync(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(errorMessage);
            await StackExchange.Exceptional.Extensions.LogNoContextAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogErrorAsync(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(errorMessage, innerException);
            await StackExchange.Exceptional.Extensions.LogNoContextAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogErrorAsync(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var errorMessage = $"Exception {innerException.Message} with input {JsonConvert.SerializeObject(inputError)}";
            return await LogErrorAsync(errorMessage, innerException, category, rollupPerServer, customData);
        }

        private Error LogDebugInternal(Exception ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            try
            {
                var isAppendFullStackTraces = StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces;
                if (isAppendFullStackTraces)
                {
                    StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces = false;
                }
                var err = StackExchange.Exceptional.Extensions.LogNoContext(ex, category, rollupPerServer, customData, DebugApplicationName);
                if (isAppendFullStackTraces)
                {
                    StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces = true;
                }
                return err;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "LogDebugInternal fail");
                return null;
            }
        }

        private async Task<Error> LogDebugInternalAsync(Exception ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            try
            {
                var isAppendFullStackTraces = StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces;
                if (isAppendFullStackTraces)
                {
                    StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces = false;
                }
                var err = await StackExchange.Exceptional.Extensions.LogNoContextAsync(ex, category, rollupPerServer, customData, DebugApplicationName);
                if (isAppendFullStackTraces)
                {
                    StackExchange.Exceptional.Exceptional.Settings.AppendFullStackTraces = true;
                }
                return err;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "LogDebugInternalAsync fail");
                return null;
            }
        }

        public new TException LogDebug<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception
        {
            LogDebugInternal(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogDebug(string message, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(message);
            LogDebugInternal(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogDebug(string message, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(message, innerException);
            LogDebugInternal(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new Exception LogDebug(object inputObject, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var errorMessage = $"Exception {innerException.Message} with input {JsonConvert.SerializeObject(inputObject)}";
            return LogDebug(errorMessage, innerException, category, rollupPerServer, customData);
        }

        public new async Task<TException> LogDebugAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception
        {
            await LogDebugInternalAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogDebugAsync(string debugMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(debugMessage);
            await LogDebugInternalAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogDebugAsync(string debugMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var ex = new Exception(debugMessage, innerException);
            await LogDebugInternalAsync(ex, category, rollupPerServer, customData);
            return ex;
        }

        public new async Task<Exception> LogDebugAsync(object inputDebug, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            var errorMessage = $"Exception {innerException.Message} with input {JsonConvert.SerializeObject(inputDebug)}";
            return await LogDebugAsync(errorMessage, innerException, category, rollupPerServer, customData);
        }
    }
}
