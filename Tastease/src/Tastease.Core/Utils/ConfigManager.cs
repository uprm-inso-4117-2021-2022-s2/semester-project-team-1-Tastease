using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.Core.Utils
{
    public static class ConfigManager
    {
        public static T GetFromAppSettingsJson<T>(string key) 
        {
            var directory = Directory.GetCurrentDirectory();
            //var env = Environment.GetEnvironmentVariable("APP_SETTINGS_CONF");
            var configs = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env}.json", optional:true)
                .Build();
            return configs.GetSection("AppSettings").GetValue<T>(key);
        }
        public static string GetConnectionStringByKey(string key) 
        {
            var directory = Directory.GetCurrentDirectory();
            //var env = Environment.GetEnvironmentVariable("APP_SETTINGS_CONF");
            var configs = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env}.json", optional:true)
                .Build();
            return configs.GetConnectionString(key);
        }
    }
}
