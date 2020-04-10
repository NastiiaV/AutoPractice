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
        public readonly IWebDriver driver;

        public BaseTest()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = PageObjectBase.implicitWait;
            driver.Navigate().GoToUrl(PageObjectBase.url);

        }
        

        
    }
}
