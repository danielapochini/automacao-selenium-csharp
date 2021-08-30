using AutomacaoSeleniumCSharp.Configuration.Interfaces;
using AutomacaoSeleniumCSharp.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.Configuration
{
    public class AppSettingsReader : IConfig
    {
        private readonly AppSettings AppSettings = new AppSettings();

        public BrowserType? GetBrowser()
        {
            string browser = AppSettings.Browser;
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetPassword()
        {
            return AppSettings.Password;
        }

        public string GetUsername()
        {
            return AppSettings.Username;
        }

        public string GetWebsite()
        {
            return AppSettings.Website;
        }
    }
}
