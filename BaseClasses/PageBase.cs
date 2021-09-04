using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.PageObject;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.BaseClasses
{
    public class PageBase
    { 
        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;

        public PageBase()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        public void Logout()
        {
            if (GenericHelper.IsElementPresent(By.XPath("//div[@id='header']/ul[1]/li[11]/a")))
            {
                ButtonHelper.ClickButton(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
            }
            GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));

        }

        public HomePage NaviGateToHomePage()
        {
            HomeLink.Click();
            return new HomePage();
        }

        public string Title
        {
            get { return ObjectRepository.Driver.Title; }
        }
    }
}
