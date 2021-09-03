using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomacaoSeleniumCSharp.Settings;

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class LoginPage
    {
        #region WebElement

         private By LoginTextBox = By.Id("Bugzilla_login");
         private By PassTextBox = By.Id("Bugzilla_password");
         private By LoginButton = By.Id("log_in");
        private By HomeLink = By.LinkText("Home");

        #endregion

        #region Actions

        public EnterBug Login(string usename, string password)
        {
            ObjectRepository.Driver.FindElement(LoginTextBox).SendKeys(usename);
            ObjectRepository.Driver.FindElement(PassTextBox).SendKeys(password);
            ObjectRepository.Driver.FindElement(LoginButton).Click();
            return new EnterBug();
        }

        #endregion

        #region Navigation

        public void NavigateToHome()
        {
            ObjectRepository.Driver.FindElement(HomeLink).Click();
        }

        #endregion
    }
}
