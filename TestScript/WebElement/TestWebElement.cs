using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;


namespace AutomacaoSeleniumCSharp.TestScript.WebElement
{
    public class TestWebElement : IClassFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestWebElement(ITestOutputHelper outputHelper)
        {
            this._outputHelper = outputHelper;
        }

        [Fact]
        public void GetElement()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            try
            {
                ReadOnlyCollection<IWebElement> collection = ObjectRepository.Driver.FindElements(By.TagName("input"));
                _outputHelper.WriteLine("Size: {0}", collection.Count);
                _outputHelper.WriteLine("Size : {0}", collection.ElementAt(0)); 
            }
            catch (NoSuchElementException e)
            {
                _outputHelper.WriteLine("Exception" + e);
            }
        }
    }
}
