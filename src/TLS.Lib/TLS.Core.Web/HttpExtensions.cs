using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.Core.Web
{
    public static class HttpExtensions
    {
        public static string GetHeaderValue(this HttpContext httpContext, string headerKey)
        {
            var values = GetHeaderValues(httpContext, headerKey);
            if (values != null)
            {
                return values.Where(m => !string.IsNullOrEmpty(m)).FirstOrDefault();
            }
            return null;
        }
        public static IEnumerable<string> GetHeaderValues(this HttpContext httpContext, string headerKey)
        {
            if (httpContext != null)
            {
                if (httpContext.Request.Headers.ContainsKey(headerKey))
                {
                    var values = httpContext.Request.Headers[headerKey];
                    return values.Select(m => m);
                }
            }
            return null;
        }
        public static string GetClientIP(this HttpContext httpContext)
        {
            try
            {
                string ip = GetHeaderValue(httpContext, "X-Forwarded-For");
                if (string.IsNullOrEmpty(ip) && httpContext != null)
                {
                    ip = httpContext.Connection.RemoteIpAddress?.ToString();
                }
                ;
                if (!string.IsNullOrEmpty(ip))
                {
                    ip = ip.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).FirstOrDefault();
                }
                return ip;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
