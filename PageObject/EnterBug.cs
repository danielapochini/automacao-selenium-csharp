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
    public class EnterBug : PageBase
    { 
        #region WebElement

        [FindsBy(How = How.LinkText, Using = "Testng")]
        private IWebElement Testng;

        #endregion
           
        #region Navigation

        public BugDetail NavigateToDetail()
        {
            Testng.Click();
            return new BugDetail();
        }
         

        #endregion
    }
}
