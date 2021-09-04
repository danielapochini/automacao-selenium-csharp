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

        [FindsBy(How = How.Id, Using = "rep_platform")]
        private IWebElement Hardware;
        //private IWebElement Hardware => driver.FindElement(By.Id("rep_platform"));

        [FindsBy(How = How.Id, Using = "op_sys")]
        private IWebElement OpSys;

        [FindsBy(How = How.Id, Using = "short_desc")]
        private IWebElement ShortDesc;
        //private IWebElement ShortDesc => driver.FindElement(By.Id("short_desc"));

        [FindsBy(How = How.Id, Using = "comment")]
        private IWebElement Comment;
        //private IWebElement Comment => driver.FindElement(By.Id("comment"));

        [FindsBy(How = How.Id, Using = "commit")]
        private IWebElement Commit;
        //private IWebElement Commit => driver.FindElement(By.Id("commit"));
        #endregion

        #region Action

        public void SelectFromSeverity(string value)
        {
            ComboBoxHelper.SelectElement(SeverityDropDown,value);
        }

        public void SelectFromCombo(string severity = null, string hardware = null, string os = null)
        {
            if (severity != null)
                ComboBoxHelper.SelectElement(SeverityDropDown, severity);
            if (hardware != null)
                ComboBoxHelper.SelectElement(Hardware, hardware);
            if (os != null)
                ComboBoxHelper.SelectElement(OpSys, os);
        }

        public void TypeIn(string summary = null, string desc = null)
        {
            if (summary != null)
                ShortDesc.SendKeys(summary);
            if (desc != null)
                Comment.SendKeys(desc);
        }

        public void ClickSubmit()
        {
            Commit.Click();
            GenericHelper.WaitForWebElementInPage(By.Id("bugzilla-body"), TimeSpan.FromSeconds(30));
        }

        public new HomePage Logout()
        {
            base.Logout();
            return new HomePage();
        }
        #endregion
    }
}
