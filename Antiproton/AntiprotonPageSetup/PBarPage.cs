namespace Antiproton.AntiprotonPageSetup
{
    public abstract class PBarPage
    {
        public PBarDriver Driver { get; set; }

        private string basePageUrl = ".protonmail.com/u/0/";

        public PBarPage()
        {

        }

        public PBarPage(PBarDriver driver)
        {
            Driver = driver;
        }

        protected virtual string RelativePageUrl { get; set; }

        protected virtual string PageDomainPrefix { get; set; }

        public string Url => $"https://{PageDomainPrefix}{basePageUrl}{RelativePageUrl}";
    }
}
