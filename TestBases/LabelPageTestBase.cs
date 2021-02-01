using Antiproton.DriverExtensions;
using Entities;

namespace TestBases
{
    public class LabelPageTestBase : TestBase
    {
        public override void BeforeEach()
        {
            base.BeforeEach();
            Driver
                .GoToPage<LogInPage>()
                .FillEmail("antiproton.test.acc@protonmail.com")
                .FillPassword("Antiproton")
                .ClickSignInButton();
        }

        public override void AfterEach()
        {
            base.AfterEach();
        }
    }
}
