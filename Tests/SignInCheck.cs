using NUnit.Framework;
using AutoTest.PageObject;

namespace AutoTest.Tests
{
    [TestFixture]
    public class SignInCheck:BaseTest
    {
        public SignInCheck():base()
        { }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        [TestCase(true, "test@gmail.com","1234")]
        [TestCase(false, "(test@gmail.com", "12345")]

        public void SignInValidation(bool isPositive, string email, string password)
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
