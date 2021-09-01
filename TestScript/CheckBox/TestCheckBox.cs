using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.CheckBox
{
    public class TestCheckBox : IAssemblyFixture<BaseClass>
    {

        private readonly ITestOutputHelper _outputHelper;

        public TestCheckBox(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact] 
        public void TestBox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

            LinkHelper.ClickLink(By.LinkText("File a Bug"));

            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));

            //IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("Bugzilla_restrictlogin"));
            //ele.Click();

            _outputHelper.WriteLine("Checkbox: " + CheckBoxHelper.IsCheckBoxChecked(By.Id("Bugzilla_restrictlogin")));

            CheckBoxHelper.CheckedCheckBox(By.Id("Bugzilla_restrictlogin"));

            _outputHelper.WriteLine("Checkbox: " + CheckBoxHelper.IsCheckBoxChecked(By.Id("Bugzilla_restrictlogin")));

        }
    }
}
