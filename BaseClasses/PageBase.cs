using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.PageObject;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomacaoSeleniumCSharp.BaseClasses
{ 
    public class PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
            this.driver = _driver;
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
            return new HomePage(ObjectRepository.Driver);
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
