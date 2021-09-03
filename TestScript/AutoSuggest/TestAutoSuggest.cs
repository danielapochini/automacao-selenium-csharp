using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.AutoSuggest
{
    public class TestAutoSuggest : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestAutoSug()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/autocomplete/index");
            //step - 1 to supply the initial string
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("countries"));
            ele.SendKeys("a");
            Thread.Sleep(1000);
            //step -2 wait for auto suggest list

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            IList<IWebElement> elements = wait.Until(GetAllElements(By.XPath("//ul[@id='countries_listbox']/child::li")));
            foreach (var ele1 in elements)
            {
                if (ele1.Text.Equals("Armenia"))
                {
                    ele1.Click();
                }
            }

            Thread.Sleep(5000);
        }

        private Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }
    }
}
