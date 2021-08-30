using AutomacaoSeleniumCSharp.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomacaoSeleniumCSharp.ComponentHelper
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url); 
        }

    }
}
