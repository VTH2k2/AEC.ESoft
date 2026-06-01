using AEC.Core.Data;
using AEC.Core.Exceptional;
using AEC.Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AEC.Core.Data;
using AEC.Core.Exceptional;

namespace AEC.Core.Service
{
    public abstract class ServiceBase<T> : ServiceBase where T : class, IService
    {
        private ILogger<T> _logger;
        protected ILogger<T> Logger
        {
            get
            {
                return _logger ??= ServiceProvider.GetRequiredService<ILogger<T>>();
            }
        }
        public ServiceBase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
    public abstract class ServiceBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SemaphoreSlim _repositoryLock, _serviceLock;
        private readonly IDictionary<Type, IRepository> _repositories;
        private readonly IDictionary<Type, IService> _services;
        protected IServiceProvider ServiceProvider
        {
            get
            {
                return _serviceProvider;
            }
        }
        protected IConfiguration Configuration
        {
            get
            {
                return _serviceProvider.GetRequiredService<IConfiguration>();
            }
        }
        private IExceptional _exceptional;
        protected IExceptional Exceptional
        {
            get
            {
                return _exceptional ??= ServiceProvider.GetRequiredService<IExceptional>();
            }
        }
        public ServiceBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _repositoryLock = new SemaphoreSlim(initialCount: 1, maxCount: 1);
            _serviceLock = new SemaphoreSlim(initialCount: 1, maxCount: 1);
            _repositories = new Dictionary<Type, IRepository>();
            _services = new Dictionary<Type, IService>();
        }

        protected T GetRepository<T>() where T : class, IRepository
        {
            var repositoryKey = typeof(T);
            if (_repositories.ContainsKey(repositoryKey))
            {
                return _repositories[repositoryKey] as T;
            }
            _repositoryLock.Wait();
            try
            {
                if (!_repositories.ContainsKey(repositoryKey))
                {
                    _repositories[repositoryKey] = ServiceProvider.GetRequiredService<T>();
                }
            }
            finally
            {
                _repositoryLock.Release();
            }
            return _repositories[repositoryKey] as T;
        }

        protected T GetService<T>() where T : class, IService
        {
            var serviceKey = typeof(T);
            if (_services.ContainsKey(serviceKey))
            {
                return _services[serviceKey] as T;
            }
            _serviceLock.Wait();
            try
            {
                if (!_services.ContainsKey(serviceKey))
                {
                    _services[serviceKey] = ServiceProvider.GetRequiredService<T>();
                }
            }
            finally
            {
                _serviceLock.Release();
            }
            return _services[serviceKey] as T;
        }

        protected TException LogError<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            return Exceptional.LogError(ex, category, rollupPerServer, customData);
        }

        protected Exception LogError(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return Exceptional.LogError(errorMessage, category, rollupPerServer, customData);
        }

        protected Exception LogError(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return Exceptional.LogError(errorMessage, innerException, category, rollupPerServer, customData);
        }

        protected Exception LogError(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return Exceptional.LogError(inputError, innerException, category, rollupPerServer, customData);
        }

        protected void LogDebug<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            Exceptional.LogDebug(ex, category, rollupPerServer, customData);
        }

        protected void LogDebug(string debugMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebug(debugMessage, category, rollupPerServer, customData);
        }

        protected void LogDebug(string debugMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebug(debugMessage, innerException, category, rollupPerServer, customData);
        }

        protected void LogDebug(object debugInput, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebug(debugInput, innerException, category, rollupPerServer, customData);
        }

        protected async Task<Exception> LogErrorAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            return await Exceptional.LogErrorAsync(ex, category, rollupPerServer, customData);
        }

        protected async Task<Exception> LogErrorAsync(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return await Exceptional.LogErrorAsync(errorMessage, category, rollupPerServer, customData);
        }

        protected async Task<Exception> LogErrorAsync(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return await Exceptional.LogErrorAsync(errorMessage, innerException, category, rollupPerServer, customData);
        }

        protected async Task<Exception> LogErrorAsync(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            return await Exceptional.LogErrorAsync(inputError, innerException, category, rollupPerServer, customData);
        }

        protected async Task LogDebugAsync<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            await Exceptional.LogDebugAsync(ex, category, rollupPerServer, customData);
        }

        protected async Task LogDebugAsync(string debugMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            await Exceptional.LogDebugAsync(debugMessage, category, rollupPerServer, customData);
        }

        protected async Task LogDebugAsync(string debugMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            await Exceptional.LogDebugAsync(debugMessage, innerException, category, rollupPerServer, customData);
        }

        protected async Task LogDebugAsync(object debugInput, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            await Exceptional.LogDebugAsync(debugInput, innerException, category, rollupPerServer, customData);
        }

        protected void LogErrorBG<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            Exceptional.LogErrorAsync(ex, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogErrorBG(string errorMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogErrorAsync(errorMessage, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogErrorBG(string errorMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogErrorAsync(errorMessage, innerException, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogErrorBG(object inputError, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogErrorAsync(inputError, innerException, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogDebugBG<TException>(TException ex, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
                    where TException : Exception
        {
            Exceptional.LogDebugAsync(ex, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogDebugBG(string debugMessage, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebugAsync(debugMessage, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogDebugBG(string debugMessage, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebugAsync(debugMessage, innerException, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }

        protected void LogDebugBG(object debugInput, Exception innerException, string category = null, bool rollupPerServer = false, Dictionary<string, string> customData = null)
        {
            Exceptional.LogDebugAsync(debugInput, innerException, category, rollupPerServer, customData).FireAndForget(Exceptional);
        }
    }
}
