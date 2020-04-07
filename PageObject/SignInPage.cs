using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTest.PageObject
{
    public class SignInPage:PageObjectBase
    {
        private static readonly By emailInput = By.Id("email");
        private static readonly By passwordInput = By.Id("passwd");
        private static readonly By isEmailOkDiv = By.XPath("//form[@id='login_form']//div[@class='form-group form-ok']");
        private static readonly By loginForm = By.Id("login_form");
        private static readonly By signInButton = By.Id("SubmitLogin");
        public SignInPage(IWebDriver driver): base(driver)
        { }

        public SignInPage EnterData(string email)
        {
            Driver.FindElement(emailInput).Click();
            Driver.FindElement(emailInput).Clear();
            Driver.FindElement(emailInput).SendKeys(email);
            Driver.FindElement(emailInput).SendKeys(Keys.Tab);

            return this;
        }

        public bool IsDataOk(string password)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

           
            wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            bool isOk = false;
            try
            {
                isOk = wait.Until(x => x.
              FindElements(isEmailOkDiv).
              Any());
                Driver.FindElement(passwordInput).SendKeys(password);
                Driver.FindElement(passwordInput).SendKeys(Keys.Tab);
                //Driver.FindElement(loginForm).Click();
                Driver.FindElement(signInButton).Click();
            }
            
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Driver not found such element");
            }

            Driver.Manage().Timeouts().ImplicitWait = implicitWait;
            return isOk;

        }
    }
}
