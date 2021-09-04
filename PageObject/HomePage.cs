﻿using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class HomePage : PageBase
    { 
        #region WebElement

        [FindsBy(How = How.Id, Using = "quicksearch_main")]
        private IWebElement QuickSearchTextBox;

        [FindsBy(How = How.Id, Using = "find")]
        [CacheLookup]
        private IWebElement QuickSearchBtn;

        [FindsBy(How = How.LinkText, Using = "File a Bug")]
        private IWebElement FileABugLink;

        #endregion
  
        #region Actions

        public void QuickSearch(string text)
        {
            QuickSearchTextBox.SendKeys(text);
            QuickSearchBtn.Click();
        }

        #endregion

        #region Navigation

        public LoginPage NavigateToLogin()
        {
            FileABugLink.Click();
            return new LoginPage();
        }

        #endregion
    }
}
