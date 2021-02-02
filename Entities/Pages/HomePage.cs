using Antiproton;
using Antiproton.AntiprotonPageSetup;

namespace Entities
{
    public class HomePage : PBarPage
    {
        protected override string RelativePageUrl { get; set; } = "overview";

        protected override string PageDomainPrefix { get; set; } = "account";

        public HomePage(PBarDriver driver) : base() => Driver = driver;
    }
}
