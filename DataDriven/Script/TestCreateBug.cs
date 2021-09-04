using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.PageObject;
using AutomacaoSeleniumCSharp.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace AutomacaoSeleniumCSharp.DataDriven.Script
{
    public class TestCreateBug : IClassFixture<BaseClass>
    {
        [Theory, CsvData("Resources/DataDriven/UsersTestData.csv")]
        public void TestBug(string severity, string hardware, string os, string summary, string desc)
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage hpPage = new HomePage();
            LoginPage loginPage = hpPage.NavigateToLogin();
            var ePage = loginPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            var bugPage = ePage.NavigateToDetail();
            bugPage.SelectFromCombo(severity, hardware, os);
            bugPage.TypeIn(summary, desc);
            bugPage.ClickSubmit();
            bugPage.Logout();
            Thread.Sleep(5000);
        }
    }
}
