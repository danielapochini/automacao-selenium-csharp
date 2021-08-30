using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.PageNavigation
{
    public class TestPageNavigation : IAssemblyFixture<BaseClass>
    {
        [Fact]
        public void OpenPage()
        {
            //INavigation page = ObjectRepository.Driver.Navigate();
            //page.GoToUrl(ObjectRepository.Config.GetWebsite());


            //ObjectRepository.Driver.Navigate().GoToUrl(ObjectRepository.Config.GetWebsite());

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

        }
    }
}
