using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium; 

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class HomePage
    {
        #region WebElement

        private By QuickSearchTextBox = By.Id("quicksearch_main");
        private By QuickSearchBtn = By.Id("find");
        private By FileABugLink = By.LinkText("File a Bug");

        #endregion

        #region Actions

        public void QuickSearch(string text)
        {
            ObjectRepository.Driver.FindElement(QuickSearchTextBox).SendKeys(text);
            ObjectRepository.Driver.FindElement(QuickSearchBtn).Click();
        }

        #endregion

        #region Navigation

        public LoginPage NavigateToLogin()
        {
            ObjectRepository.Driver.FindElement(FileABugLink).Click();
            return new LoginPage();
        }

        #endregion
    }
}
