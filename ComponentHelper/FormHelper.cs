using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.ComponentHelper
{
    public class FormHelper
    {
        private static IWebElement _element;

        public static void SubmitForm(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Submit();
        }

    }
}
