
using OpenQA.Selenium;

namespace AutoTest.PageObject
{
    public class Header : PageObjectBase
    {
        private static readonly By loginButton = By.ClassName("login");
        

        public Header(IWebDriver driver) : base(driver)
        { }

        public SignInPage ClickOnSignIn()
        {
            Driver.FindElement(loginButton).Click();
            return new SignInPage(Driver);
        }

    }
}
