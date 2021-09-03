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

namespace AutomacaoSeleniumCSharp.TestScript.RadioButton
{
    public class TestHandleRadioButton : IClassFixture<BaseClass>
    {
        private readonly ITestOutputHelper _outputHelper;

        public TestHandleRadioButton(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void TestRadio()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            IWebElement webelemt = ObjectRepository.Driver.FindElement(By.XPath("//a[@id='enter_bug']/span"));
            _outputHelper.WriteLine("Text : {0}", webelemt.Text);

            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.LinkText("Testng"));
            LinkHelper.ClickLink(By.XPath("//div[@id='header']/ul[1]/li[9]/a"));
            LinkHelper.ClickLink(By.XPath("//dt[@id='parameters']/a"));

            //IWebElement element = ObjectRepository.Driver.FindElement(By.Id("ssl_redirect-on"));
            //element.Click();

            _outputHelper.WriteLine("Selected : {0}", RadioButtonHelper.IsRadioButtonSelected(By.Id("ssl_redirect-off")));
            RadioButtonHelper.ClickRadioButton(By.Id("ssl_redirect-on"));
        }
    }
}
