using Antiproton.DriverExtensions;
using Entities;

namespace TestBases
{
    public class LabelPageTestBase : TestBase
    {
        protected LabelPage labelPage;

        public override void BeforeEach()
        {
            base.BeforeEach();
            
            Driver
                .GoToPage<LogInPage>()
                .FillEmail("antiproton.test.acc@protonmail.com")
                .FillPassword("Antiproton")
                .ClickSignInButton();

            labelPage = Driver
                .GoToPage<LabelPage>();
        }

        public override void AfterEach()
        {
            base.AfterEach();
        }
    }
}
