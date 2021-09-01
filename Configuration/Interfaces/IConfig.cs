using AutomacaoSeleniumCSharp.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.Configuration.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
