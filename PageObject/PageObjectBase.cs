using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace AutoTest.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        public static readonly string url = "http://automationpractice.com/index.php";
        public static readonly TimeSpan implicitWait = TimeSpan.FromSeconds(3);
        public WebDriverWait wait;
        protected PageObjectBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
