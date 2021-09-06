using AutomacaoSeleniumCSharp.ComponentHelper;
using System;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Sdk;

namespace AutomacaoSeleniumCSharp.Specflow.Steps
{
    [Binding]
    public class HooksSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            NavigationHelper.NavigateToUrl("http://www.google.com");
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            throw new XunitException("Error message.");
        }
        
        [When(@"I press sub")]
        public void WhenIPressSub()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
