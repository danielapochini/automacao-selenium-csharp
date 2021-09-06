using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace AutomacaoSeleniumCSharp.TestScript.HyperLink
{
    public class TestHyperLink : IClassFixture<BaseClass>
    {
        [Fact]
        public void ClickLink()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            
            //IWebElement elementTwo = ObjectRepository.Driver.FindElement(By.LinkText("File"));
            //IWebElement element = ObjectRepository.Driver.FindElement(By.LinkText("File a Bug"));
            //element.Click();  
            
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
        }
    }
}
