using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.Popups
{
    public class TestPopups : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestAlert()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
            JavaScriptExecutor.ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");
            
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup(); 

            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            TextBoxHelper.ClearTextBox(By.Id("textareaCode"));
            TextBoxHelper.TypeInTextBox(By.Id("textareaCode"), text);
        }

        [Fact]
        public void TestConfimPopup()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup(); 

            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
        }

        [Fact]
        public void TestPrompt()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text);
            JavaScriptPopHelper.ClickOkOnPopup();
            BrowserHelper.RefreshPage();
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text + "abc");
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
        }
    }
}
