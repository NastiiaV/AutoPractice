using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTest.PageObject
{
    public class SearchPage : PageObjectBase
    {
        private static readonly By search = By.Id("search_query_top");
        private static readonly By buttonSearch = By.XPath("//button[@name ='submit_search']");

        private static readonly By alertParagraph  = By.XPath("//div[@id='center_column']//p[@class ='alert alert-warning']");
        public SearchPage(IWebDriver driver): base(driver)
        { }

        public SearchPage EnterData(string searchData)
        {
            Driver.FindElement(search).Clear();
            Driver.FindElement(search).Click();
            Driver.FindElement(search).SendKeys(searchData);
            Driver.FindElement(search).SendKeys(Keys.Tab);
            Driver.FindElement(buttonSearch).Click();
            return this;
        }

        public bool isSearchOk()
        {
            bool isSearchExist = false;

            try
            {
                Driver.FindElement(alertParagraph);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Driver not found such element");
                isSearchExist = true;
            }

            return isSearchExist;
        }
    }
}
