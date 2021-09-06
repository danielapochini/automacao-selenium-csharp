using AutomacaoSeleniumCSharp.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace AutomacaoSeleniumCSharp.Specflow.Hooks
{
    [Binding]
    public class GeneralHook : XunitContextBase
    {
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext; 

        public GeneralHook(ITestOutputHelper output) : base(output)
        {
        }

        [BeforeFeature("Tag1")]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("BeforeFeature Hook");
        }

        [AfterFeature("Tag1")]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Hook");
        }

        [BeforeScenario("Tag1")]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario Hook");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine("AfterScenario Hook");
            if (_scenarioContext.TestError != null)
            {
                string name = _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
                GenericHelper.TakeScreenshot(name);
                //GenericHelper.TakeScreenShot("testdir",name);
                Console.WriteLine(_scenarioContext.TestError.Message);
                Console.WriteLine(_scenarioContext.TestError.StackTrace);
            }
        }

        [BeforeScenario]
        public static void BeforeScenarioContextInjection(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

    }
}
