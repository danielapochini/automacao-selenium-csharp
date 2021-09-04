using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomacaoSeleniumCSharp.ComponentHelper;
using SeleniumExtras.PageObjects;
using AutomacaoSeleniumCSharp.Settings;
using AutomacaoSeleniumCSharp.BaseClasses;

namespace AutomacaoSeleniumCSharp.PageObject
{
    public class BugDetail : PageBase
    { 
        #region WebElement

        [FindsBy(How = How.Id, Using = "bug_severity")]
        private IWebElement SeverityDropDown;

        #endregion
           
        #region Action

        public void SelectFromSeverity(string value)
        {
            ComboBoxHelper.SelectElement(SeverityDropDown,value);
        }

        #endregion
    }
}
