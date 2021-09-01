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

namespace AutomacaoSeleniumCSharp.TestScript.Button
{
    public class TestHandleButton : IAssemblyFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestHandleButton(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void TestButton()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());

            //IWebElement element =  ObjectRepository.Driver.FindElement(By.Id("log_in"));
            // element.Click();
             
            _outputHelper.WriteLine("Enabled : {0}", ButtonHelper.IsButtonEnabled(By.Id("log_in")));
            _outputHelper.WriteLine("Button Text : {0}", ButtonHelper.GetButtonText(By.Id("log_in")));

            ButtonHelper.ClickButton(By.Id("log_in"));
        }
    }
}
