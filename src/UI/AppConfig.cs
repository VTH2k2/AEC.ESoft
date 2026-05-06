using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class AppConfig
    {
        public static string ApiBaseUrl =>
            ConfigurationManager.AppSettings["ApiBaseUrl"];
    }
}
