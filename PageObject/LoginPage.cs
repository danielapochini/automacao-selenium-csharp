using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomacaoSeleniumCSharp.Settings;
using SeleniumExtras.PageObjects;
using AutomacaoSeleniumCSharp.BaseClasses;

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class LoginPage : PageBase
    { 
        #region WebElement

        [FindsBy(How = How.Id, Using = "Bugzilla_login")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.Id, Using = "Bugzilla_password")]
        private IWebElement PassTextBox;

        [FindsBy(How = How.Id, Using = "log_in")]
        [CacheLookup]
        private IWebElement LoginButton;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;

        #endregion
         
        #region Actions

        public EnterBug Login(string usename, string password)
        {
            LoginTextBox.SendKeys(usename);
            PassTextBox.SendKeys(password);
            LoginButton.Click();
            return new EnterBug(); 
        }

        #endregion

        #region Navigation

        public HomePage NavigateToHome()
        {
            HomeLink.Click();
            return new HomePage();
        }

        #endregion
    }
}
