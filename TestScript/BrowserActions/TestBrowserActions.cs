using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.BrowserActions
{
    public class TestBrowserActions : IClassFixture<BaseClass>
    {
       [Fact]
       public void TestActions()
        {
            NavigationHelper.NavigateToUrl("https://br.yahoo.com/");
            TextBoxHelper.TypeInTextBox(By.XPath("//input[@id='ybar-sbq']"),
               "C#");
            FormHelper.SubmitForm(By.CssSelector("#ybar-search"));
            BrowserHelper.GoBack();
            BrowserHelper.Forward();
            BrowserHelper.RefreshPage();
        }
    }
}
