using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using AutomacaoSeleniumCSharp.PageObject;
using AutomacaoSeleniumCSharp.Settings;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomacaoSeleniumCSharp.Specflow.Steps 
{
    [Binding]
    public class TestFeatureSteps
    {
        private HomePage hPage;
        private LoginPage lPage;
        private EnterBug ePage;
        private BugDetail bPage;

        #region Given
        [Given(@"User is at Home Page")]
        public void GivenUserIsAtHomePage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
        }
        
        [Given(@"File a Bug should be visible")]
        public void GivenFileABugShouldBeVisible()
        {
            Assert.True(GenericHelper.IsElementPresent(By.Id("enter_bug")));
        }

        #endregion

        #region When
        [When(@"I click on File a Bug Link")]
        public void WhenIClickOnFileABugLink()
        {
            ObjectRepository.hPage = new HomePage(ObjectRepository.Driver);
            ObjectRepository.lPage = ObjectRepository.hPage.NavigateToLogin();
            lPage = ObjectRepository.lPage;
        }
        
        [When(@"I provide the username, password and click on Login button")]
        public void WhenIProvideTheUsernamePasswordAndClickOnLoginButton()
        {
            ePage = lPage.Login(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            ObjectRepository.ePage = ePage;
        }
        
        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            ObjectRepository.ePage.Logout();
        }
        
        [When(@"I click on  Testng link")]
        public void WhenIClickOnTestngLink()
        {
            ObjectRepository.bPage = ePage.NavigateToDetail();
        }
        
        [When(@"I provide the severity , harware , platform and summary")]
        public void WhenIProvideTheSeverityHarwarePlatformAndSummary()
        {
            ObjectRepository.bPage.SelectFromCombo("critical", "Macintosh", "Other");
            ObjectRepository.bPage.TypeIn("Summary 1", "Desc - 1");
        }
        
        [When(@"click on Submit button")]
        public void WhenClickOnSubmitButton()
        {
            ObjectRepository.bPage.ClickSubmit();
        }

        #endregion

        #region Then

        [Then(@"User should be at Login Page")]
        public void ThenUserShouldBeAtLoginPage()
        {
            Assert.Equal("Log in to Bugzilla", ObjectRepository.lPage.Title);
        }

        [Then(@"User Should be at Enter Bug page")]
        public void ThenUserShouldBeAtEnterBugPage()
        {
            Assert.Equal("Enter Bug", ObjectRepository.ePage.Title);
        }

        [Then(@"User should be logged out and should be at Home Page")]
        public void ThenUserShouldBeLoggedOutAndShouldBeAtHomePage()
        {
            Assert.True(GenericHelper.IsElementPresent(By.Id("welcome")));      
        }
        
        [Then(@"User Should be at Bug Detail page")]
        public void ThenUserShouldBeAtBugDetailPage()
        {
            Assert.Equal("Enter Bug: Testng", ObjectRepository.bPage.Title);
        }
        
        [Then(@"Bug should get created")]
        public void ThenBugShouldGetCreated()
        {
            Assert.True(GenericHelper.IsElementPresent(By.Id("commit_top")));
        }
        
        [Then(@"User should be at Search page")]
        public void ThenUserShouldBeAtSearchPage()
        {
        }

        #endregion
    }
}
