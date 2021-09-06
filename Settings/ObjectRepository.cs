using AutomacaoSeleniumCSharp.Configuration.Interfaces;
using AutomacaoSeleniumCSharp.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static HomePage hPage;
        public static LoginPage lPage;
        public static EnterBug ePage;
        public static BugDetail bPage;
    }
}
