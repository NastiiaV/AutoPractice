using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
