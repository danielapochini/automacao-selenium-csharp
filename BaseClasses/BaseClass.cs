using AutomacaoSeleniumCSharp.Configuration;
using AutomacaoSeleniumCSharp.CustomException;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
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
         

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            }; 
            return options;
        }


        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
            return option;
        }


        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true, 
                ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom, 
                IgnoreZoomLevel = true,
                PageLoadStrategy = PageLoadStrategy.Normal,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss,
                EnableNativeEvents = true,
            };
            options.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
            options.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true); 
            return options;
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
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
