using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT.Persistance.infinity.Util
{
    class Configuration
    {
        private static IConfigurationRoot _configuration = null;

        public static void BuildConfig()
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(GetProjectDir())
            //    .AddJsonFile("appsettings.json", true)
            //    .AddEnvironmentVariables();

            //_configuration = config.Build();
        }

        public static string GetConnectionString(string name)
        {
            return Manager().GetConnectionString(name);
        }

        static IConfigurationRoot Manager()
        {
            if (_configuration == null)
            {
                BuildConfig();
            }
            return _configuration;
        }

        static string GetProjectDir()
        {
            string e = Environment.CurrentDirectory;
            string debugDir = "\\bin\\Debug\\";
            int index = e.IndexOf(debugDir);
            string Dir = e.Substring(0, index);
            return Dir;
        }
    }
}
