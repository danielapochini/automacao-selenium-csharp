using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;


namespace AutomacaoSeleniumCSharp.TestScript.PageNavigation
{
    public class TestPageNavigation : IClassFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestPageNavigation(ITestOutputHelper outputHelper)
        {
            this._outputHelper = outputHelper;
        }
        [Fact]
        public void OpenPage()
        {
            //INavigation page = ObjectRepository.Driver.Navigate();
            //page.GoToUrl(ObjectRepository.Config.GetWebsite());


            //ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            _outputHelper.WriteLine("Title of the page: {0}", WindowHelper.GetTitle());
        }
    }
}
