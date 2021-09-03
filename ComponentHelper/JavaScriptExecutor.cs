using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.ComponentHelper
{
    public class JavaScriptExecutor
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver); 
            return executor.ExecuteScript(script);
        }
    }
}
