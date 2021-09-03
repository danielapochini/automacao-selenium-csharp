using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Extensions.AssemblyFixture;

namespace AutomacaoSeleniumCSharp.TestScript.MouseAction
{
    public class TestMouseAction : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("draggable"));


            act.ContextClick(ele)
                .Build()
                .Perform();

            Thread.Sleep(5000);
        }

        [Fact]
        public void DragNDrop()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.Id("droptarget"));

            act.DragAndDrop(src, tar)
                .Build()
                .Perform();

            Thread.Sleep(4000);
        }

        [Fact]
        public void TestClicknHold()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]/span"));
            act.ClickAndHold(ele)
                .MoveToElement(tar, 0, 30)
                .Release()
                .Build()
                .Perform();

            Thread.Sleep(10000);
        }

        [Fact]
        public void TestKeyBoard()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Actions act = new Actions(ObjectRepository.Driver); 

            IWebElement ele1 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_top"));
            IWebElement ele2 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_main"));
            ele1.SendKeys("fx");

            act.KeyDown(ele2, Keys.LeftShift)
                .SendKeys(ele2, "f")
                .SendKeys(ele2, "x")
                .KeyUp(ele2, Keys.LeftShift)
                .Build()
                .Perform();
            Thread.Sleep(5000);

        }
    }
}
