using AutomacaoSeleniumCSharp.BaseClasses;
using AutomacaoSeleniumCSharp.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutomacaoSeleniumCSharp.TestScript.Grid
{
    public class TestWebTable : IClassFixture<BaseClass>
    {
        [Fact]
        public void TestGrid()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/grid/custom-command");
            GridHelper.ClickButtonInGrid("//div[@class='k-grid-content k-auto-scrollable']//table[@role='grid']", 2, 3);
        }
    }
}
