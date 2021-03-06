using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.ComponentHelper
{
    public class TextBoxHelper
    {
        private static IWebElement element;
        public static void TypeInTextBox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);
        }

        public static void ClearTextBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
        }
    }
}
