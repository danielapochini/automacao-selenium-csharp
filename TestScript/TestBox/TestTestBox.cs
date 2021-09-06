using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace AutomacaoSeleniumCSharp.TestScript.TestBox
{
    public class TestTestBox : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestBox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite()); 

            LinkHelper.ClickLink(By.LinkText("File a Bug")); 

            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
        }
    }
}
