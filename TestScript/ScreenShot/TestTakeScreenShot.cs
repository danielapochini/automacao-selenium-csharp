using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.ScreenShot
{
    public class TestTakeScreenShot : IAssemblyFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestTakeScreenShot(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        } 

        [Fact]
        public void ScreenShot()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
             
            GenericHelper.TakeScreenshot();
            GenericHelper.TakeScreenshot("Test.jpeg");
        }
    }
}
