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

namespace AutomacaoSeleniumCSharp.TestScript.WebDriverWaiter
{
    public class TestWebDriverWait : IAssemblyFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestWebDriverWait(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void TestWait()
        {
            //SetPageLoadTimeout - For controlling the page load time
            //ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            
            NavigationHelper.NavigateToUrl("https://www.bing.com/?cc=br");
            TextBoxHelper.TypeInTextBox(By.XPath("//input[@id='ybar-sbq']"),
               "C#");
        }

        [Fact]
        public void TestDynamicWait()
        { 
            NavigationHelper.NavigateToUrl("https://br.yahoo.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
             
            //wait.Until(WaitForSearchBox());
            //wait.Until(WaitForTitle());

            wait.Until(WaitForElement()).SendKeys("health");
            FormHelper.SubmitForm(By.CssSelector("#ybar-search"));
            wait.Until(WaitForLastElement()).Click();
            //_outputHelper.WriteLine("Title : {0}", wait.Until(WaitForPageTitle()));
        }


        //acc -spe fun<in,out> { () => {}}

        private Func<IWebDriver, bool> WaitForSearchBox()
        {
            return ((x) =>
            {
                _outputHelper.WriteLine("Waiting for Search Box");
                return x.FindElements(By.XPath("//input[@id='ybar-sbq']")).Count == 1;
            });
        }

        private Func<IWebDriver, string> WaitForTitle()
        {
            return ((x) =>
            {
                if (x.Title.Contains("Bing"))
                    return x.Title;
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> WaitForElement()
        {
            return ((x) =>
            {
                _outputHelper.WriteLine("Waiting for Search Text box");
                _outputHelper.WriteLine("Waiting for element");
                if (x.FindElements(By.XPath("//input[@id='ybar-sbq']")).Count == 1)
                    return x.FindElement(By.XPath("//input[@id='ybar-sbq']"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> WaitForLastElement()
        {
            return ((x) =>
            {
                _outputHelper.WriteLine("Waiting for Last Element");
                if (
                    x.FindElements(
                        By.LinkText("Medical Health")).Count ==
                    1)
                    return
                        x.FindElement(
                            By.LinkText("Medical Health"));
                return null;
            });
        }

        private Func<IWebDriver, string> WaitForPageTitle()
        {
            return ((x) =>
            {
                _outputHelper.WriteLine("Waiting for Title");
                if (
                    x.FindElements(By.XPath("//h2[contains(text(),'Seja Bem Vindo')]")).Count == 1)
                    return x.FindElement(By.CssSelector("//h2[contains(text(),'Seja Bem Vindo')]")).Text;
                return null;
            });
        }
    }
}
