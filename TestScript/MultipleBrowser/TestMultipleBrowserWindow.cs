using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace AutomacaoSeleniumCSharp.TestScript.MultipleBrowser
{
    public class TestMultipleBrowserWindow : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestMultipleWindow()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(2);
            ButtonHelper.ClickButton(By.XPath("//button[@id='runbtn']"));
            BrowserHelper.SwitchToParent();

        }

        [Fact]
        public void TestFrame()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            //ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            ButtonHelper.ClickButton(By.XPath("//button[@id='runbtn']"));

        }
    }
}
