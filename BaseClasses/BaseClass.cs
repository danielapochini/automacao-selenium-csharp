using AutomacaoSeleniumCSharp.Configuration;
using AutomacaoSeleniumCSharp.CustomException;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

[assembly: TestFramework(AssemblyFixtureFramework.TypeName, AssemblyFixtureFramework.AssemblyName)]

namespace AutomacaoSeleniumCSharp.BaseClasses
{
    public class BaseClass : IDisposable
    {
        public BaseClass()
        {
            InitWebdriver();
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver();
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver();
            return driver;
        }


        public static void InitWebdriver()
        {
            ObjectRepository.Config = new AppSettingsReader(); 
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver(); 

                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver(); 
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver(); 
                    break;
                      

                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            } 
        }

        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            } 
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}
