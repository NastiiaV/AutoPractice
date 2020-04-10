using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoTest.PageObject;


namespace AutoTest
{
    [TestFixture]
    public class SearchCheck:BaseTest
    {

        public SearchCheck():base()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        [TestCase(true, "dress")]
        [TestCase(false, "asd")]
        public void Search(bool isPositive, string someSearch)
        {
            SearchPage searchPage = new SearchPage(driver);
            bool isSearchExist = searchPage.EnterData(someSearch).isSearchOk();
            Assert.That(isSearchExist, Is.EqualTo(isPositive), $"Search is {(isSearchExist ? "existed" : "not existed")} " +
                "but we expected opposite");
        }
    }
}
