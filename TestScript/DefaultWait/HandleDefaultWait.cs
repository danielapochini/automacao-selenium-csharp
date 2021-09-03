using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.DefaultWait
{
    public class HandleDefaultWait : IClassFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public HandleDefaultWait(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
         
        public void TestDefaultWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.LinkText("Testng"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));

            GenericHelper.WaitForWebElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            IWebElement ele = GenericHelper.WaitForWebElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));

            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Console.WriteLine("After wait : {0}", wait.Until(ChangeOfValue()));

        }


        private Func<IWebElement, string> ChangeOfValue()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for value change");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("major"))
                    return select.SelectedOption.Text;
                return null;
            });
        }
    }
}
