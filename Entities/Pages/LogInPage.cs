using Antiproton;
using Antiproton.AntiprotonPageSetup;
using OpenQA.Selenium;

namespace Entities
{
    public class LogInPage : PBarPage
    {
        protected override string RelativePageUrl { get; set; } = "login";
        protected override string PageDomainPrefix { get; set; } = "account";

        protected PBarElement Email => new PBarElement(Driver, By.Id("login"));

        protected PBarElement Password => new PBarElement(Driver, By.Id("password"));

        protected PBarElement SignInButton => new PBarElement(Driver, By.CssSelector("button[data-cy-login='submit']"));

        public LogInPage FillEmail(string email)
        {
            Email
                .ClearWithCtrlADelete()
                .SendKeys(email);

            return this;
        }

        public LogInPage FillPassword(string password)
        {
            Password
                .Clear()
                .SendKeys(password);

            return this;
        }

        public HomePage ClickSignInButton()
        {
            SignInButton
                .ClickAndWaitForUrlChange();

            return new HomePage(Driver);
        }

        public HomePage LogIn(string email, string password)
        {
            return FillEmail(email)
                .FillPassword(password)
                .ClickSignInButton();
        }
    }
}
