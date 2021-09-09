using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Configuration;
using AutomacaoSeleniumCSharp.CustomException;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using Xunit; 
 
namespace AutomacaoSeleniumCSharp.BaseClasses
{
    [Binding]
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
            option.AddArgument("no-sandbox");
            option.AddArgument("proxy-server='direct://'");
            option.AddArgument("proxy-bypass-list=*");
            //option.AddArgument("--headless");
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
            ChromeDriver driver = new ChromeDriver(
                ChromeDriverService.CreateDefaultService(), 
                GetChromeOptions(), 
                TimeSpan.FromMinutes(5)
            );
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        [BeforeScenario]
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
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad.Add(TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut()));
            ObjectRepository.Driver.Manage().
                Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut()));
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            BrowserHelper.BrowserMaximize();
        }

        [AfterScenario]
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
