using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.FindElements
{
    public class TestHandleElements : IClassFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestHandleElements(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void GetAllElements()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//input"));
            //ReadOnlyCollection<IWebElement> elements2 = ObjectRepository.Driver.FindElements(By.Id("123"));
            
            foreach (var ele in elements)
            {
                _outputHelper.WriteLine("ID : {0}", ele.GetAttribute("id"));
            }
        }
    }
}
