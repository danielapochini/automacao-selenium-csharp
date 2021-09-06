using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;


namespace AutomacaoSeleniumCSharp.TestScript.JavaScript
{
    public class TestJavaScriptClass : IClassFixture<BaseClass>
    {
        private readonly By CourseLink = By.XPath("//div[@data-purpose='course-container']/a[@href='/course/selenium-with-c/']");
        private readonly By ShowMore = By.XPath("//h2[@data-purpose='title']/following-sibling::div/button");

        [Fact]
        public void TestScrollClick()
        {
            NavigationHelper.NavigateToUrl("https://www.udemy.com/course/bdd-with-selenium-webdriver-and-speckflow-using-c/");

            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;

            IWebElement element = ObjectRepository.Driver.FindElement(ShowMore);

            executor.ExecuteScript("window.scrollTo(0," + (element.Location.Y - 100) + ")");

            // if neede add dynamic wait

            element.Click();

            element = ObjectRepository.Driver.FindElement(CourseLink);

            executor.ExecuteScript("window.scrollTo(0," + (element.Location.Y - 100) + ")");

            // if neede add dynamic wait

            element.Click();

            Thread.Sleep(200);
        }
    }
}
