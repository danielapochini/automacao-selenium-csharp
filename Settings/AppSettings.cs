using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomacaoSeleniumCSharp.Settings
{
    public class AppSettings
    {
        public string Browser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string PageLoadTimeOut { get; set; }
        public string ElementLoadTimeOut { get; set; }

        public AppSettings()
        {
            Browser = ReturnParamAppSettings("Browser");
            Username = ReturnParamAppSettings("User");
            Password = ReturnParamAppSettings("Password");
            Website = ReturnParamAppSettings("Website");
            PageLoadTimeOut = ReturnParamAppSettings("PageLoadTimeOut");
            ElementLoadTimeOut = ReturnParamAppSettings("ElementLoadTimeOut");
        }
         
        public static string ReturnParamAppSettings(string nameParam)
        {

            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()) 
               .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            return config[nameParam].ToString();
        }
    }
}
