using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using AutoTest.PageObject;

namespace AutoTest
{
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver driver;

        public BaseTest()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = PageObjectBase.implicitWait;
            driver.Navigate().GoToUrl(PageObjectBase.url);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        //[TestCase(true, "dress")]
        [TestCase(false, "asd")]
        public void Search(bool isPositive, string someSearch)
        {
            SearchPage searchPage = new SearchPage(driver);
            bool isSearchExist = searchPage.EnterData(someSearch).isSearchOk();
            Assert.That(isSearchExist, Is.EqualTo(isPositive), $"Search is {(isSearchExist ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        //[TestCase(true, "test@gmail.com","1234")]
        [TestCase(false, "(test@gmail.com","12345")]

        public void SignInValidation(bool isPositive, string email,string password)
        {

            Header header = new Header(driver);
            SignInPage signInPage = header.ClickOnSignIn();
            bool isDataOk = signInPage.EnterData(email).IsDataOk(password);

            Assert.That(isDataOk,
                Is.EqualTo(isPositive), $"Email was validated {(isDataOk ? "successfully" : "unseccessfully")} " +
                "but we expected opposite");

        }

        
    }
}
