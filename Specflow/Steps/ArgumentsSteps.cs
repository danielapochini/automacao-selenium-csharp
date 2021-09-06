using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.PageObject;
using AutomacaoSeleniumCSharp.Settings;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomacaoSeleniumCSharp.Specflow.Steps 
{
    [Binding]
    public class ArgumentsSteps  
    { 
        #region Given
        [Given(@"User is at Home Page with url ""(.*)""")]
        public void GivenUserIsAtHomePageWithUrl(string url)
        {
            NavigationHelper.NavigateToUrl(url);
        }
        #endregion

        #region When 

        [When(@"I click on ""(.*)"" Link")]
        public void WhenIClickOnLink(string linkText)
        {
            ObjectRepository.hPage = new HomePage(ObjectRepository.Driver);
            ObjectRepository.lPage = ObjectRepository.hPage.NavigateToLogin();
        }
         
        [When(@"I provide the ""(.*)"", ""(.*)"" and click on Login button")]
        public void WhenIProvideTheAndClickOnLoginButton(string user, string pass)
        {
            ObjectRepository.ePage = ObjectRepository.lPage.Login(user, pass);
        } 
          
        [When(@"I click on Testng link in the page")]
        public void WhenIClickOnTestngLinkInThePage()
        {
            ObjectRepository.bPage = ObjectRepository.ePage.NavigateToDetail();
        }

        [When(@"I provide the severity , harware , platform , summary and desc")]
        public void WhenIProvideTheSeverityHarwarePlatformSummaryAndDesc(Table table)
        {
            foreach (var row in table.Rows)
            {
                ObjectRepository.bPage.SelectFromCombo(row["Severity"], row["Harware"], row["Platform"]);
                ObjectRepository.bPage.TypeIn(row["Summary"], row["Desc"]);
            }
        }

        [When(@"click on Submit button in page")]
        public void WhenClickOnSubmitButtonInPage()
        {
            ObjectRepository.bPage.ClickSubmit();
        }

        [When(@"I click on Logout button at bug detail page")]
        [When(@"I click on Logout button at enter bug page")]
        public void WhenIClickOnLogoutButtonAtEnterBugPage()
        {
            ObjectRepository.ePage.Logout();
        }

        [When(@"I provide the ""(.*)"" , ""(.*)"" , ""(.*)"" , ""(.*)"" and ""(.*)""")]
        public void WhenIProvideTheAnd(string severity, string harware, string platform, string summary, string desc)
        {
            ObjectRepository.bPage.SelectFromCombo(severity, harware, platform);
            ObjectRepository.bPage.TypeIn(summary, desc);
        }


        #endregion

        #region Then

        [Then(@"User should be at Login Page with title ""(.*)""")]
        public void ThenUserShouldBeAtLoginPageWithTitle(string title)
        {
            Assert.Equal(title, ObjectRepository.lPage.Title);
        }

        [Then(@"User Should be at Enter Bug page with title ""(.*)""")]
        public void ThenUserShouldBeAtEnterBugPageWithTitle(string title)
        {
            Assert.Equal(title, ObjectRepository.lPage.Title);
        }
         

        [Then(@"User Should be at Bug Detail page with title ""(.*)""")]
        public void ThenUserShouldBeAtBugDetailPageWithTitle(string title)
        {
            Assert.Equal(title, ObjectRepository.bPage.Title);
        }
        #endregion
    }
}
