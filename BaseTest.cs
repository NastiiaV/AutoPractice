using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTest.PageObject;

namespace AutoTest
{
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver driver;
        //private static readonly string url = "http://automationpractice.com/index.php";
        //private static readonly TimeSpan implicitWait = TimeSpan.FromSeconds(3);
        //private WebDriverWait wait;

        public BaseTest()
        {
            //driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver = new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = PageObjectBase.implicitWait;
            driver.Navigate().GoToUrl(PageObjectBase.url);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        //[TestCase(true, "dress")]
        //[TestCase(false, "asd")]
        public void Search(bool isPositive, string someSearch)
        {
            //Header header = new Header(driver);
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
            bool isEmailOk = signInPage.EnterData(email).IsDataOk(password);

            Assert.That(isEmailOk,
                Is.EqualTo(isPositive), $"Email was validated {(isEmailOk ? "successfully" : "unseccessfully")} " +
                "but we expected opposite");

        }

        
    }
}
