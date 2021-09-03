using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomacaoSeleniumCSharp.Settings;

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class EnterBug
    {
        #region WenElement

         private By Testng = By.LinkText("Testng");

        #endregion

        #region Navigation

        public BugDetail NavigateToDetail()
        {
            ObjectRepository.Driver.FindElement(Testng).Click();
            return new BugDetail();
        }
         

        #endregion
    }
}
