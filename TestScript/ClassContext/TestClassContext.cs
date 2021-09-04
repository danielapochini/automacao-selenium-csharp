using AutomacaoSeleniumCSharp.BaseClasses;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AutomacaoSeleniumCSharp.TestScript.ClassContext
{
    public class TestClassContext : XunitContextBase, IClassFixture<BaseClass>
    {
        public TestClassContext(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestCase1()
        { 
            Console.WriteLine("Test Name: {0}", Context.Test.DisplayName);
        }

        [Fact]
        public void TestCase2()
        {
            Console.WriteLine("Test Name: {0}", Context.Test.DisplayName);
        }
         
    }
}
