using AEC.Core.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Service;

namespace AEC.Core.Exceptional
{
    public interface IExceptional : IService
    {
        TException LogError<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception;
        Exception LogError(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Exception LogError(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Exception LogError(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<TException> LogErrorAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception;
        Task<Exception> LogErrorAsync(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<Exception> LogErrorAsync(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<Exception> LogErrorAsync(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        TException LogDebug<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception;
        Exception LogDebug(string message, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Exception LogDebug(string message, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Exception LogDebug(object inputObject, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<TException> LogDebugAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
            where TException : Exception;
        Task<Exception> LogDebugAsync(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<Exception> LogDebugAsync(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
        Task<Exception> LogDebugAsync(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null);
    }
}
